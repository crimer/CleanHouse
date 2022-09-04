using System.Reactive.Subjects;

namespace CleanHouse.MviCommon
{
    public abstract class BaseState<TState>
    {
        public readonly Subject<TState> State = new Subject<TState>();

        public void Set(TState state)
        {
            State.OnNext(state);
        }
    }
}