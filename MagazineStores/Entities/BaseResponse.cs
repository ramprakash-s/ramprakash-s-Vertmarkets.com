namespace MagazineStores.Entities
{
    public class BaseResponse
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseResponse"/> is success.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }
}
