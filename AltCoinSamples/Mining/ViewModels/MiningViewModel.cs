// <copyright file="MiningViewModel.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     MiningViewModel: Class for the Mining window view-model.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Mining.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Security.Cryptography;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows;
    using BWHazel.Apps.AltCoinSamples.Common;
    using BWHazel.Apps.AltCoinSamples.Mining.Models;

    /// <summary>
    /// Mining window view-model.
    /// </summary>
    public class MiningViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The input text.
        /// </summary>
        private string inputText;

        /// <summary>
        /// The target.
        /// </summary>
        private string target;

        /// <summary>
        /// The target type.
        /// </summary>
        private TargetType targetType;

        /// <summary>
        /// The number of blocks.
        /// </summary>
        private int blocks;

        /// <summary>
        /// The current block being solved.
        /// </summary>
        private int currentBlock;

        /// <summary>
        /// The value indicating whether controls are enabled.
        /// </summary>
        private bool controlsEnabled;

        /// <summary>
        /// The command to solve the blocks.
        /// </summary>
        private Command solveBlocksCommand;

        /// <summary>
        /// The Mining model.
        /// </summary>
        private MiningModel mining;

        /// <summary>
        /// The solved blocks.
        /// </summary>
        private ObservableCollection<BlockInfo> solvedBlocks;

        /// <summary>
        /// Initialises a new instance of the <see cref="MiningViewModel"/> class.
        /// </summary>
        public MiningViewModel()
        {
            this.mining = new MiningModel(new MD5CryptoServiceProvider());
            this.PropertyChanged += this.PropertyChangedHandler;
            this.ControlsEnabled = true;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the input text.
        /// </summary>
        public string InputText
        {
            get
            {
                if (this.inputText == null)
                {
                    this.inputText = string.Empty;
                }

                return this.inputText;
            }

            set
            {
                if (string.Equals(value, this.inputText) == false)
                {
                    this.inputText = value;
                    this.OnPropertyChanged("InputText");
                }
            }
        }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public string Target
        {
            get
            {
                if (this.target == null)
                {
                    this.target = string.Empty;
                }

                return this.target;
            }

            set
            {
                if (string.Equals(value, this.target) == false)
                {
                    this.target = value;
                    this.OnPropertyChanged("Target");
                }
            }
        }

        /// <summary>
        /// Gets or sets the target type.
        /// </summary>
        public TargetType TargetType
        {
            get
            {
                return this.targetType;
            }

            set
            {
                if (value != this.targetType)
                {
                    this.targetType = value;
                    this.OnPropertyChanged("TargetType");
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of blocks.
        /// </summary>
        public int Blocks
        {
            get
            {
                if (this.blocks < 1)
                {
                    this.blocks = 1;
                }

                return this.blocks;
            }

            set
            {
                if (value != this.blocks)
                {
                    this.blocks = value;
                    this.OnPropertyChanged("Blocks");
                }
            }
        }

        /// <summary>
        /// Gets or sets the current block being solved.
        /// </summary>
        public int CurrentBlock
        {
            get
            {
                return this.currentBlock;
            }

            set
            {
                if (value != this.currentBlock)
                {
                    this.currentBlock = value;
                    this.OnPropertyChanged("CurrentBlock");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether controls are enabled.
        /// </summary>
        public bool ControlsEnabled
        {
            get
            {
                return this.controlsEnabled;
            }

            set
            {
                if (value != this.controlsEnabled)
                {
                    this.controlsEnabled = value;
                    this.OnPropertyChanged("ControlsEnabled");
                }
            }
        }

        /// <summary>
        /// Gets or sets the solved blocks.
        /// </summary>
        public ObservableCollection<BlockInfo> SolvedBlocks
        {
            get
            {
                if (this.solvedBlocks == null)
                {
                    this.solvedBlocks = new ObservableCollection<BlockInfo>();
                }

                return this.solvedBlocks;
            }

            set
            {
                if (object.Equals(value, this.solvedBlocks) == false)
                {
                    this.solvedBlocks = value;
                    this.OnPropertyChanged("SolvedBlocks");
                }
            }
        }

        /// <summary>
        /// Gets the command to solve the blocks.
        /// </summary>
        public Command SolveBlocksCommand
        {
            get
            {
                if (this.solveBlocksCommand == null)
                {
                    this.solveBlocksCommand = new Command((data) =>
                    {
                        this.SolvedBlocks.Clear();
                        try
                        {
                            this.CheckTarget();
                            Task.Run(() =>
                            {
                                this.ControlsEnabled = false;
                                bool isLimitTarget = this.TargetType != TargetType.Zero;
                                Tuple<string, long> solvedBlock = new Tuple<string, long>(this.InputText, 0);
                                Action<BlockInfo> collectionAddMethod = this.SolvedBlocks.Add;
                                for (int i = 1; i <= this.Blocks; i++)
                                {
                                    solvedBlock = this.mining.SolveBlock(solvedBlock.Item1, this.Target, isLimitTarget);
                                    BlockInfo solvedBlockInfo = new BlockInfo(i, solvedBlock.Item1, solvedBlock.Item2);
                                    Application.Current.Dispatcher.BeginInvoke(collectionAddMethod, solvedBlockInfo);
                                    this.CurrentBlock = i;
                                }

                                this.ControlsEnabled = true;
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Mining", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    });
                }

                return this.solveBlocksCommand;
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
                case "Blocks":
                    this.CurrentBlock = 0;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the target when the <see cref="TargetType"/> is set to Auto.
        /// </summary>
        /// <remarks>
        /// The target is based on the hash of the current date and time with a random number of zeros
        /// replacing the first characters.
        /// </remarks>
        /// <returns>The target when the <see cref="TargetType"/> is set to Auto.</returns>
        private string GetAutoHash()
        {
            byte[] dateHash = this.mining.ComputeHash(DateTime.Now.ToString());
            string dateHashHex = this.mining.GetHexadecimalRepresentation(dateHash);
            Random random = new Random(DateTime.Now.Millisecond);
            int zeros = random.Next(1, 5);
            string zeroString = string.Empty.PadLeft(zeros, '0');
            return dateHashHex.Replace(dateHashHex.Substring(0, zeros), zeroString);
        }

        /// <summary>
        /// Check the target for errors and set its value if required.
        /// </summary>
        private void CheckTarget()
        {
            if (this.TargetType != TargetType.Auto && this.Target == string.Empty)
            {
                this.TargetType = TargetType.Auto;
            }

            if (this.TargetType == TargetType.Auto)
            {
                this.Target = this.GetAutoHash();
            }
            else if (this.TargetType == TargetType.Text)
            {
                byte[] targetHash = this.mining.ComputeHash(this.Target);
                this.Target = this.mining.GetHexadecimalRepresentation(targetHash);
            }
            else if (this.TargetType == TargetType.Zero)
            {
                if (!Regex.IsMatch(this.Target, @"^0*$"))
                {
                    throw new Exception("Invalid target for current mode.");
                }
            }
        }
    }
}
