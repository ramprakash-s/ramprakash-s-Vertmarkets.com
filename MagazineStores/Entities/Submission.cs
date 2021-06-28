using System.Collections.Generic;

namespace MagazineStores.Entities
{
    public class Submission
    {
        /// <summary>
        /// Gets or sets the total time.
        /// </summary>
        public string TotalTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [answer correct].
        /// </summary>
        public bool AnswerCorrect { get; set; }

        /// <summary>
        /// Gets or sets the should be.
        /// </summary>
        public List<string> ShouldBe { get; set; }
    }
}
