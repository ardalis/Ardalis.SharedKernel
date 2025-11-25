using Mediator;

namespace Ardalis.SharedKernel;

public interface IDomainEvent : INotification
{
  DateTime DateOccurred { get; }
}
