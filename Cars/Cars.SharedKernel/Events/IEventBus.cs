using System;

namespace Cars.SharedKernel.Events;

public interface IEventBus
{
    IDisposable Subscribe<T>(Action<T> action) where T : IEvent;

    void Publish<T>(T item) where T : IEvent;
}