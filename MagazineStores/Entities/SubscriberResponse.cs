using System.Collections.Generic;

namespace MagazineStores.Entities
{
    public class SubscriberResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<Subscriber> Data { get; set; }
    }
}
