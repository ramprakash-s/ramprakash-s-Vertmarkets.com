using MagazineStores.Entities;
using MagazineStores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazineStores.Business
{
    public class MagazineStore : IMagazineStore
    {
        private readonly IMagazineStoreService _magazineStoreService;
        /// <summary>
        /// Logger
        /// </summary>
       // private readonly IAppLogger<MagazineStore> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MagazineStore"/> class.
        /// </summary>
        /// <param name="magazineStoreStoreService"></param>
        public MagazineStore(IMagazineStoreService magazineStoreStoreService)
        {
            _magazineStoreService = magazineStoreStoreService;
            // _logger = logger;
        }

        /// <summary>
        /// Finds the subcribers that are subscribed to at least
        /// one magazine from each category
        /// </summary>
        /// <returns></returns>
        public async Task<SubmissionResponse> FindsubcribersToAllCategories()
        {

            var categories = await _magazineStoreService.GetCategories();

            var subscribers = await _magazineStoreService.GetSubscribers();
            var magazineTasks = new List<Task<List<Magazine>>>();

            categories.ForEach(category => magazineTasks.Add(_magazineStoreService.GetMagazines(category)));

            Task.WaitAll(magazineTasks.ToArray());

            var subcribersToAllCategories = from subscriber in subscribers.SelectMany(s => s.MagazineIds,
                    (subscriber, magazineId) => new { SubscriberId = subscriber.Id, MagazineId = magazineId })
                                            join magazine in magazineTasks.SelectMany(x => x.Result)
                                                on subscriber.MagazineId equals magazine.Id
                                            select new
                                            {
                                                subscriber.SubscriberId,
                                                magazine.Category
                                            }
                into subscriberCategory
                                            group subscriberCategory by subscriberCategory.SubscriberId
                into subscriberGrouping
                                            select new
                                            {
                                                SubcriberId = subscriberGrouping.Key,
                                                CategoryCount = subscriberGrouping.Distinct().Count()
                                            }
                into subscriberCategoryCount
                                            where subscriberCategoryCount.CategoryCount == categories.Count
                                            select subscriberCategoryCount.SubcriberId;

            return await _magazineStoreService.SubmitAnswer(subcribersToAllCategories);
        }
    }
}