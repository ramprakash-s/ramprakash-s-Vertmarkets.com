using System.Collections.Generic;

namespace MagazineStores.Entities
{
    public class MagazineResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<Magazine> Data { get; set; }
    }
}
