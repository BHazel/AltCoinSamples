// <copyright file="TargetType.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     TargetType: Enumeration defining constants for the different target types.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Mining
{
    /// <summary>
    /// Defines constants for the different target types.
    /// </summary>
    public enum TargetType
    {
        /// <summary>Set automatically.</summary>
        Auto,
        
        /// <summary>Numeric value to which hashes will be compared to determine if they are lower.</summary>
        Limit,
        
        /// <summary>Set to the hash of specified text.</summary>
        Text,
        
        /// <summary>String of zeros to which the beginning of hashes will be compared to for equality.</summary>
        Zero
    }
}
