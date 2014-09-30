// <copyright file="HashesViewModel.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     HashesViewModel: Class for the Hashes window view model.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Hashing.ViewModels
{
    using System.ComponentModel;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Media;
    using BWHazel.Apps.AltCoinSamples.Common;
    using BWHazel.Apps.AltCoinSamples.Hashing.Models;

    /// <summary>
    /// Hashes window view model.
    /// </summary>
    public class HashesViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The first text sample.
        /// </summary>
        private string textSample1;

        /// <summary>
        /// The second text sample.
        /// </summary>
        private string textSample2;

        /// <summary>
        /// The first hash.
        /// </summary>
        private string hash1;

        /// <summary>
        /// The second hash.
        /// </summary>
        private string hash2;

        /// <summary>
        /// The flag to determine if the text samples are equal.
        /// </summary>
        private string dataEquality;

        /// <summary>
        /// The data equality text block foreground colour.
        /// </summary>
        private Brush dataEqualityColour;

        /// <summary>
        /// The hash similarity.
        /// </summary>
        private string hashSimilarity;

        /// <summary>
        /// The hash similarity text block foreground colour.
        /// </summary>
        private Brush hashSimilarityColour;

        /// <summary>
        /// The command to compute the hash.
        /// </summary>
        private Command computeHashesCommand;

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
            this.DataEqualityColour = Brushes.Gray;
            this.PropertyChanged += this.PropertyChangedHandler;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the first text sample.
        /// </summary>
        public string TextSample1
        {
            get
            {
                if (this.textSample1 == null)
                {
                    this.textSample1 = string.Empty;
                }

                return this.textSample1;
            }

            set
            {
                if (string.Equals(value, this.textSample1) == false)
                {
                    this.textSample1 = value;
                    this.OnPropertyChanged("TextSample1");
                }
            }
        }

        /// <summary>
        /// Gets or sets the second text sample.
        /// </summary>
        public string TextSample2
        {
            get
            {
                if (this.textSample2 == null)
                {
                    this.textSample2 = string.Empty;
                }

                return this.textSample2;
            }

            set
            {
                if (string.Equals(value, this.textSample2) == false)
                {
                    this.textSample2 = value;
                    this.OnPropertyChanged("TextSample2");
                }
            }
        }

        /// <summary>
        /// Gets or sets the first hash.
        /// </summary>
        public string Hash1
        {
            get
            {
                return this.hash1;
            }

            set
            {
                if (string.Equals(value, this.hash1) == false)
                {
                    this.hash1 = value;
                    this.OnPropertyChanged("Hash1");
                }
            }
        }

        /// <summary>
        /// Gets or sets the second hash.
        /// </summary>
        public string Hash2
        {
            get
            {
                return this.hash2;
            }

            set
            {
                if (string.Equals(value, this.hash2) == false)
                {
                    this.hash2 = value;
                    this.OnPropertyChanged("Hash2");
                }
            }
        }

        /// <summary>
        /// Gets or sets the flag to determine if the text samples are equal.
        /// </summary>
        public string DataEquality
        {
            get
            {
                return this.dataEquality;
            }

            set
            {
                if (string.Equals(value, this.dataEquality) == false)
                {
                    this.dataEquality = value;
                    this.OnPropertyChanged("DataEquality");
                }
            }
        }

        /// <summary>
        /// Gets or sets the data equality text block foreground colour.
        /// </summary>
        public Brush DataEqualityColour
        {
            get
            {
                return this.dataEqualityColour;
            }

            set
            {
                if (Brush.Equals(this.dataEqualityColour, value) == false)
                {
                    this.dataEqualityColour = value;
                    this.OnPropertyChanged("DataEqualityColour");
                }
            }
        }

        /// <summary>
        /// Gets or sets the hash similarity.
        /// </summary>
        public string HashSimilarity
        {
            get
            {
                return this.hashSimilarity;
            }

            set
            {
                if (string.Equals(value, this.hashSimilarity) == false)
                {
                    this.hashSimilarity = value;
                    this.OnPropertyChanged("HashSimilarity");
                }
            }
        }

        /// <summary>
        /// Gets or sets the hash similarity text block foreground colour.
        /// </summary>
        public Brush HashSimilarityColour
        {
            get
            {
                return this.hashSimilarityColour;
            }

            set
            {
                if (Brush.Equals(this.hashSimilarityColour, value) == false)
                {
                    this.hashSimilarityColour = value;
                    this.OnPropertyChanged("HashSimilarityColour");
                }
            }
        }

        /// <summary>
        /// Gets the command to compute the hash.
        /// </summary>
        public Command ComputeHashesCommand
        {
            get
            {
                if (this.computeHashesCommand == null)
                {
                    this.computeHashesCommand = new Command((text) =>
                    {
                        this.Hash1 = this.hashes.ComputeHash(this.TextSample1);
                        this.Hash2 = this.hashes.ComputeHash(this.TextSample2);
                        this.DataEquality = string.Equals(this.Hash1, this.Hash2).ToString();
                    });
                }

                return this.computeHashesCommand;
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

        /// <summary>
        /// Handles the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Information relating to the event.</param>
        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "DataEquality":
                    if (this.DataEquality.ToLower() == "true")
                    {
                        this.DataEqualityColour = Brushes.Green;
                    }
                    else if (this.DataEquality.ToLower() == "false")
                    {
                        this.DataEqualityColour = Brushes.Red;
                    }
                    else
                    {
                        this.DataEqualityColour = Brushes.Black;
                    }

                    break;
                case "Hash1":
                case "Hash2":
                    if (this.Hash1 == null || this.Hash2 == null)
                    {
                        return;
                    }

                    StringBuilder comparedHashesStringBuilder = new StringBuilder();
                    for (int i = 0; i < this.Hash1.Length; i++)
                    {
                        if (this.Hash1[i] == this.Hash2[i])
                        {
                            comparedHashesStringBuilder.Append(this.Hash1[i]);
                        }
                        else
                        {
                            comparedHashesStringBuilder.Append("_");
                        }
                    }

                    this.HashSimilarity = comparedHashesStringBuilder.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
