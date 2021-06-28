using System.Collections.Generic;
using System.Threading.Tasks;
using MagazineStores.Entities;

namespace MagazineStores.Interfaces
{
    public interface IMagazineStoreService
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetCategories();

        /// <summary>
        /// Gets the subscribers.
        /// </summary>
        /// <returns></returns>
        Task<List<Subscriber>> GetSubscribers();

        /// <summary>
        /// Gets the magazines.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        Task<List<Magazine>> GetMagazines(string category);

        /// <summary>
        /// Submits the answer.
        /// </summary>
        /// <param name="subcribers">The subcribers.</param>
        /// <returns></returns>
        Task<SubmissionResponse> SubmitAnswer(IEnumerable<string> subcribers);
    }
}
