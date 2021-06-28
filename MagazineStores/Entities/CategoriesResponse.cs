using System.Collections.Generic;

namespace MagazineStores.Entities
{
    public class CategoriesResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<string> Data { get; set; }
    }
}
