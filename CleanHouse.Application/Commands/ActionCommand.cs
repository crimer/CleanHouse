using System;

namespace CleanHouse.Application.Commands
{
    /// <summary>
    /// Команда
    /// </summary>
    public class ActionCommand : BaseCommand
    {
        readonly Func<object, bool> _canExecute;
        readonly Action<object> _execute;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Callback действия</param>
        public ActionCommand(Action<object> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Callback действия</param>
        public ActionCommand(Action execute) : this(o => execute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Callback действия</param>
        /// <param name="canExecute">Callback на возможность выполнения</param>
        public ActionCommand(Action<object> execute, Func<object, bool> canExecute) : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Callback действия</param>
        /// <param name="canExecute">Callback на возможность выполнения</param>
        public ActionCommand(Action execute, Func<bool> canExecute) : this(o => execute(), o => canExecute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        /// <inheritdoc />
        public override void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <inheritdoc />
        public override bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }
    }
    
    /// <summary>
    /// Обобщенная команд
    /// </summary>
    /// <typeparam name="T">Тип данных (результат выполнения команды)</typeparam>
    public sealed class ActionCommand<T> : ActionCommand
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Callback действия</param>
        public ActionCommand(Action<T> execute) : base(o => execute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Callback действия</param>
        /// <param name="canExecute">Callback на возможность выполнения</param>
        public ActionCommand(Action<T> execute, Func<T, bool> canExecute) : base(o => execute((T)o), o => canExecute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }
    }
}