// <copyright file="MainWindow.xaml.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     MainWindow: Class for the main window logic.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Hashing
{
    using System.Windows;
    using BWHazel.Apps.AltCoinSamples.Hashing.ViewModels;

    /// <summary>
    /// Main window logic.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The Hashes tab view model.
        /// </summary>
        private HashesViewModel hashesViewModel;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.InitialiseViewModels();
            this.DataContext = this.hashesViewModel;
        }

        /// <summary>
        /// Initialises the view models for the main window.
        /// </summary>
        private void InitialiseViewModels()
        {
            this.hashesViewModel = new HashesViewModel();
        }
    }
}
