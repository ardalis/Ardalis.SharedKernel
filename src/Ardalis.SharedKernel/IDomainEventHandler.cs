using Mediator;

namespace Ardalis.SharedKernel;

public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{
}
