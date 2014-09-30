// <copyright file="BlockInfo.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     BlockInfo: Class with information on a solved block.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Mining.Models
{
    /// <summary>
    /// Information on a solved block.
    /// </summary>
    public struct BlockInfo
    {
        /// <summary>
        /// The block ID.
        /// </summary>
        private int id;

        /// <summary>
        /// The successful hash which solved the block.
        /// </summary>
        private string successfulHash;

        /// <summary>
        /// The number of attempts to solve the block.
        /// </summary>
        private int attempts;

        /// <summary>
        /// Initialises a new instance of the <see cref="BlockInfo"/> struct.
        /// </summary>
        /// <param name="id">The block ID.</param>
        /// <param name="successfulHash">The successful hash which solved the block.</param>
        /// <param name="attempts">The number of attempts to solve the block.</param>
        public BlockInfo(int id, string successfulHash, int attempts)
        {
            this.id = id;
            this.successfulHash = successfulHash;
            this.attempts = attempts;
        }

        /// <summary>
        /// Gets or sets the block ID.
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets the successful hash which solved the block.
        /// </summary>
        public string SuccessfulHash
        {
            get { return this.successfulHash; }
            set { this.successfulHash = value; }
        }

        /// <summary>
        /// Gets or sets the number of attempts to solve the block.
        /// </summary>
        public int Attempts
        {
            get { return this.attempts; }
            set { this.attempts = value; }
        }
    }
}
