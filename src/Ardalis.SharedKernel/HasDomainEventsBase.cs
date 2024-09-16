using System.ComponentModel.DataAnnotations.Schema;

namespace Ardalis.SharedKernel;

public abstract class HasDomainEventsBase : IHasDomainEvents
{
  private readonly List<DomainEventBase> _domainEvents = new();
  [NotMapped]
  public IReadOnlyCollection<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
  internal void ClearDomainEvents() => _domainEvents.Clear();
}
