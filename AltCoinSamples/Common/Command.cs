// <copyright file="Command.cs" company="Benedict W. Hazel">
//     Benedict W. Hazel, 2014
// </copyright>
// <author>Benedict W. Hazel</author>
// <summary>
//     Command: Class for a basic command.
// </summary>

namespace BWHazel.Apps.AltCoinSamples.Common
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A basic command.
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// The action to perform.
        /// </summary>
        private Action<object> action;

        /// <summary>
        /// Initialises a new instance of the <see cref="Command"/> class with the specified action to perform.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        public Command(Action<object> action)
        {
            this.action = action;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Returns a value to determine if the command can execute.
        /// </summary>
        /// <param name="parameter">The parameter for the command.</param>
        /// <returns><c>true</c> if the command can execute, otherwise <c>false</c>.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">The parameter for the command.</param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}
