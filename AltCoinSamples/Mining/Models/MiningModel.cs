// <copyright file="MiningModel.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     MiningModel: Class to simulate the mining process.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Mining.Models
{
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// Simulates the mining process.
    /// </summary>
    public class MiningModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MiningModel"/> class with specified <see cref="HashAlgorithm"/>.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        public MiningModel(HashAlgorithm hashAlgorithm)
        {
            this.HashAlgorithm = hashAlgorithm;
        }

        /// <summary>
        /// Gets or sets the hash algorithm.
        /// </summary>
        public HashAlgorithm HashAlgorithm { get; set; }

        /// <summary>
        /// Solves a block with a specified input and target criterion.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="input">The input.</param>
        /// <returns>The hash meeting the target criterion and the hash count required to meet it as a <see cref="Tuple{T1, T2}"/>.</returns>
        public Tuple<string, int> SolveBlock(string target, string input)
        {
            return new Tuple<string, int>(string.Empty, 0);
        }
    }
}
