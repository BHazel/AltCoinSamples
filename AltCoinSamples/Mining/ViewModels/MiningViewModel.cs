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
                if (this.targetType == 0)
                {
                    this.targetType = TargetType.Zero;
                }

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
        /// Gets or sets the command to solve the blocks.
        /// </summary>
        public Command SolveBlocksCommand
        {
            get
            {
                if (this.solveBlocksCommand == null)
                {
                    this.solveBlocksCommand = new Command((data) =>
                    {
                        Task.Run(() =>
                        {
                            bool isLimitTarget = (this.TargetType == TargetType.Limit);
                            Tuple<string, long> solvedBlock = new Tuple<string, long>(this.InputText, 0);
                            Action<BlockInfo> collectionAddMethod = this.SolvedBlocks.Add;
                            for (int i = 1; i <= this.Blocks; i++)
                            {
                                solvedBlock = this.mining.SolveBlock(solvedBlock.Item1, this.Target, isLimitTarget);
                                BlockInfo solvedBlockInfo = new BlockInfo(i, solvedBlock.Item1, solvedBlock.Item2);
                                Application.Current.Dispatcher.BeginInvoke(collectionAddMethod, solvedBlockInfo);
                                this.CurrentBlock = i;
                            }
                        });

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
        }
    }
}
