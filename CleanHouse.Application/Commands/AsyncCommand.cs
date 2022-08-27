using System;
using System.Threading.Tasks;
using CleanHouse.Application.Helpers;

namespace CleanHouse.Application.Commands
{
    /// <summary>
    ///  Асинхронная команда
    /// </summary>
    public class AsyncCommand : BaseCommand
    {
        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly IErrorHandler _errorHandler;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Callback на выполнение</param>
        /// <param name="canExecute">Callback на возможность выполнения</param>
        /// <param name="errorHandler">Обработчик ошибки</param>
        public AsyncCommand(
            Func<Task> execute,
            Func<bool> canExecute = null,
            IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }
        
        /// <inheritdoc />
        public override bool CanExecute(object parameter = null)
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        /// <summary>
        /// Выполнение ассинхронно
        /// </summary>
        private async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }
            OnCanExecutedChanged();
        }
        
        /// <inheritdoc />
        public override void Execute(object parameter)
        {
            ExecuteAsync().ExecuteSafeAsync(_errorHandler);
        }
    }
    
    /// <summary>
    /// Обобщенная асинхронная команд
    /// </summary>
    /// <typeparam name="T">Тип данных (результат выполнения команды)</typeparam>
    public class AsyncCommand<T> : BaseCommand
    {
        private bool _isExecuting;
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;
        private readonly IErrorHandler _errorHandler;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Callback на выполнение</param>
        /// <param name="canExecute">Callback на возможность выполнения</param>
        /// <param name="errorHandler">Обработчик ошибки</param>
        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        /// <inheritdoc />
        public override bool CanExecute(object parameter)
        {
             return !_isExecuting && (_canExecute?.Invoke((T)parameter) ?? true);
        }

        /// <inheritdoc />
        public override void Execute(object parameter)
        {
            ExecuteAsync((T)parameter).ExecuteSafeAsync(_errorHandler);
        }

        /// <summary>
        /// Выполнить асинхронно
        /// </summary>
        /// <param name="parameter">Данные</param>
        private async Task ExecuteAsync(T parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    _isExecuting = true;
                    await _execute(parameter);
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            OnCanExecutedChanged();
        }
    }
}