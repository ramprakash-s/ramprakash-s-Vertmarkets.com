using System.Collections.Generic;

namespace MagazineStores.Entities
{

    public class Subscriber
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>

        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>

        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the magazine ids.
        /// </summary>
        public List<int> MagazineIds { get; set; } = new List<int>();
    }
}
