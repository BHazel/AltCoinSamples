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
    using System.Numerics;
    using System.Security.Cryptography;
    using System.Text;

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
        /// <param name="input">The input.</param>
        /// <param name="target">The target.</param>
        /// <param name="limitTarget"><c>true</c> if the target is a string representation of the target hash.</param>
        /// <returns>The hash meeting the target criterion and the hash count required to meet it as a <see cref="Tuple{T1, T2}"/>.</returns>
        public Tuple<string, long> SolveBlock(string input, string target, bool limitTarget)
        {
            long nonce = 0;
            bool blockSolved = false;
            string hash = string.Empty;
            while (blockSolved == false)
            {
                string inputWithNonce = string.Concat(input, nonce.ToString());
                hash = this.GetHexadecimalHash(inputWithNonce);
                nonce += 1;

                if (limitTarget == true)
                {
                    BigInteger targetNumeric = BigInteger.Parse(target);
                    BigInteger hashNumeric = BigInteger.Parse(hash);
                    if (hashNumeric < targetNumeric)
                    {
                        blockSolved = true;
                    }
                }
                else
                {
                    if (hash.StartsWith(target))
                    {
                        blockSolved = true;
                    }
                }
            }

            return new Tuple<string, long>(hash, nonce);
        }

        /// <summary>
        /// Computes the hash of the specified text.
        /// </summary>
        /// <param name="text">The text to compute the hash of.</param>
        /// <returns>The hash as a byte array.</returns>
        public byte[] ComputeHash(string text)
        {
            return this.HashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(text));
        }

        /// <summary>
        /// Computes the hash for the specified text.
        /// </summary>
        /// <param name="input">The text.</param>
        /// <returns>The hexadecimal representation of the hash as a string.</returns>
        private string GetHexadecimalHash(string input)
        {
            byte[] hashBytes = this.ComputeHash(input);
            StringBuilder hexadecimalHashBuilder = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hexadecimalHashBuilder.AppendFormat("{0:x2}", b);
            }

            return hexadecimalHashBuilder.ToString();
        }
    }
}
