using System.Reactive.Subjects;

namespace CleanHouse.MviCommon
{
    public abstract class BaseEvent<TEvent>
    {
        public readonly Subject<TEvent> Event = new Subject<TEvent>();
        public void Emit(TEvent @event) => Event.OnNext(@event);
    }
}