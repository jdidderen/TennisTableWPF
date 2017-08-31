using System;
using System.Windows.Input;

namespace TennisTableWPF.Services
{
    /// <inheritdoc />
    /// <summary>
    /// To register commands in MMVM pattern
    /// </summary>
    internal class RelayCommands : ICommand
    {
        public readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        /// <inheritdoc />
        /// <summary>
        /// Constructer takes Execute events to register in CommandManager.
        /// </summary>
        /// <param name="execute">Execute method as action.</param>
        public RelayCommands(Action<object> execute)
            : this(execute, null)
        {
            _execute = execute ?? throw new NotImplementedException("Not implemented");
        }
        /// <summary>
        /// Constructer takes Execute and CanExcecute events to register in CommandManager.
        /// </summary>
        /// <param name="execute">Execute method as action.</param>
        /// <param name="canExecute">CanExecute method as return bool type.</param>
        public RelayCommands(Action<object> execute, Predicate<object> canExecute)
        {
            try
            {
                _execute = execute ?? throw new NotImplementedException("Not implemented");
                _canExecute = canExecute;
            }
            catch (Exception)
            {
                // ignored
            }
        }
        /// <summary>
        /// Can Executed Changed Event
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        /// <inheritdoc />
        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="parameter">Method parameter.</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        /// <inheritdoc />
        /// <summary>
        /// CanExecute method.
        /// </summary>
        /// <param name="parameter">Method parameter.</param>
        /// <returns>Return true if can execute.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
    }
}