using Mediator;

namespace Acme.SharedKernel;

public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{
}
