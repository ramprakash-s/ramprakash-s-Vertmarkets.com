namespace MagazineStores.Entities
{
    public class MagazineStoreConfiguration
    {
        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>        
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the time out in seconds.
        /// </summary>
        public int TimeOutInSeconds { get; set; }

    }
}
