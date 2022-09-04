using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace CleanHouse.Utils.Extensions
{
    public static class ExExtensions
    {
        public static IDisposable SubscribeAsync<TResult>(this IObservable<TResult> source, Func<Task> action) =>
            source.Select(_ => Observable.FromAsync(action))
                .Concat()
                .Subscribe();
        
        public static IDisposable SubscribeAsync<TResult>(this IObservable<TResult> source, Func<TResult, Task> action) =>
            source.Select(d => Observable.FromAsync(() => action(d)))
                .Concat()
                .Subscribe();
    }
}