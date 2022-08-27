using System;
using System.Windows.Input;

namespace CleanHouse.Application.Commands
{
    /// <summary>
    /// Базовая команда 
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// События изменения возможности выполнения 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Метод возможности выполнения
        /// </summary>
        public virtual bool CanExecute(object parameter) => true;

        /// <summary>
        /// Выполнить
        /// </summary>
        public abstract void Execute(object parameter);

        /// <summary>
        /// Метод вызова собятия изменения возможности выполнения 
        /// </summary>
        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}