using System.Reactive.Subjects;

namespace CleanHouse.Presenters
{
    public abstract class BaseState<TState>
    {
        public Subject<TState> State { get; } = new Subject<TState>();

        public void Set(TState state)
        {
            State.OnNext(state);
        }
    }
}