namespace Ardalis.SharedKernel;

/// <summary>
/// A simple interface for sending domain events. Can use MediatR or any other implementation.
/// </summary>
public interface IDomainEventDispatcher
{
  Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents);
}
