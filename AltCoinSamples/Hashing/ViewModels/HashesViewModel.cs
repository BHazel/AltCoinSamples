// <copyright file="HashesViewModel.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     HashesViewModel: Class for the Hashes tab view model.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Hashing.ViewModels
{
    using System.ComponentModel;
    using System.Security.Cryptography;
    using BWHazel.Apps.AltCoinSamples.Hashing.Models;

    /// <summary>
    /// Hashes tab view model.
    /// </summary>
    public class HashesViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The text.
        /// </summary>
        private string text;

        /// <summary>
        /// The hash.
        /// </summary>
        private string hash;

        /// <summary>
        /// The command to compute the hash.
        /// </summary>
        private Command computeHashCommand;

        /// <summary>
        /// The Hashes model.
        /// </summary>
        private HashesModel hashes;

        /// <summary>
        /// Initialises a new instance of the <see cref="HashesViewModel"/> class.
        /// </summary>
        public HashesViewModel()
        {
            this.hashes = new HashesModel(new SHA256CryptoServiceProvider());
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (string.Equals(value, this.text) == false)
                {
                    this.text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }

        /// <summary>
        /// Gets or sets the hash.
        /// </summary>
        public string Hash
        {
            get
            {
                return this.hash;
            }

            set
            {
                if (string.Equals(value, this.hash) == false)
                {
                    this.hash = value;
                    this.OnPropertyChanged("Hash");
                }
            }
        }

        /// <summary>
        /// Gets the command to compute the hash.
        /// </summary>
        public Command ComputeHashCommand
        {
            get
            {
                if (this.computeHashCommand == null)
                {
                    this.computeHashCommand = new Command((text) =>
                    {
                        this.Hash = this.hashes.ComputeHash(text.ToString());
                    });
                }

                return this.computeHashCommand;
            }
        }

        /// <summary>
        /// Handler for the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="name">The property name.</param>
        protected void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
