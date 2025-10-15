using Mediator;
using Microsoft.Extensions.Logging;

namespace Ardalis.SharedKernel;

public class MediatorDomainEventDispatcher : IDomainEventDispatcher
{
  private readonly IMediator _mediator;
  private readonly ILogger<MediatorDomainEventDispatcher> _logger;

  public MediatorDomainEventDispatcher(IMediator mediator, ILogger<MediatorDomainEventDispatcher> logger)
  {
    _mediator = mediator;
    _logger = logger;
  }

  public async Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents)
  {
    foreach (IHasDomainEvents entity in entitiesWithEvents)
    {
      if (entity is IHasDomainEvents hasDomainEvents)
      {
        IDomainEvent[] events = hasDomainEvents.DomainEvents.ToArray();
        hasDomainEvents.ClearDomainEvents();

        foreach (var domainEvent in events)
          await _mediator.Publish(domainEvent).ConfigureAwait(false);
      }
      else
      {
        _logger.LogError(
          "Entity of type {EntityType} does not inherit from {BaseType}. Unable to clear domain events.",
          entity.GetType().Name,
          nameof(IHasDomainEvents));
      }
    }
  }
}
