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
    using System.Security.Cryptography;
    using BWHazel.Apps.AltCoinSamples.Mining.Models;

    /// <summary>
    /// Mining window view-model.
    /// </summary>
    public class MiningViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The Mining model.
        /// </summary>
        private MiningModel mining;

        /// <summary>
        /// Initialises a new instance of the <see cref="MiningViewModel"/> class.
        /// </summary>
        public MiningViewModel()
        {
            this.mining = new MiningModel(new MD5CryptoServiceProvider());
            this.PropertyChanged += this.PropertyChangedHandler;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Handles the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Information relating to the event.</param>
        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}
