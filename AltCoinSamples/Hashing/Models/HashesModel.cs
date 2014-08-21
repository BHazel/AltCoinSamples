// <copyright file="HashesModel.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     HashesModel: Class for computing a hash.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Hashing.Models
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Computes a hash.
    /// </summary>
    public class HashesModel
    {   
        /// <summary>
        /// Initialises a new instance of the <see cref="HashesModel"/> class with specified <see cref="HashAlgorithm"/>.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        public HashesModel(HashAlgorithm hashAlgorithm)
        {
            this.HashAlgorithm = hashAlgorithm;
        }

        /// <summary>
        /// Gets or sets the hash algorithm.
        /// </summary>
        public HashAlgorithm HashAlgorithm { get; set; }

        /// <summary>
        /// Computes the hash for the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>The base 64 string of the hash.</returns>
        public string ComputeHash(string text)
        {
            byte[] hashBytes = this.HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(hashBytes);
        }
    }
}
