using Mediator;

namespace Acme.SharedKernel;

public interface IDomainEvent : INotification
{
  DateTime DateOccurred { get; }
}
