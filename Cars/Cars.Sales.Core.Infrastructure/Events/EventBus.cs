using Cars.SharedKernel.Events;
using Cars.SharedKernel;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Cars.Sales.Core.Infrastructure.Events;

public class EventBus(IAppLogger logger) : IEventBus
{
    private readonly Subject<object> eventBus = new();

    public IDisposable Subscribe<T>(Action<T> action) where T : IEvent
    {
        var disposable = eventBus.OfType<T>().Subscribe(action);
        logger.Trace($"{GetType().Name} => {typeof(T).Name} was subscribed by {action.Target?.GetType().Name}");
        return disposable;
    }

    public void Publish<T>(T item) where T : IEvent
    {
        eventBus.OnNext(item);
        logger.Trace($"{GetType().Name} => published event {item.GetType().Name}");
    }
}