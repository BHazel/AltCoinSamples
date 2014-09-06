// <copyright file="MiningViewModel.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     MiningViewModel: Class for the Mining window view-model.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Mining.ViewModels
{
    using System.ComponentModel;
    using BWHazel.Apps.AltCoinSamples.Mining.Models;

    /// <summary>
    /// Mining window view-model.
    /// </summary>
    public class MiningViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
