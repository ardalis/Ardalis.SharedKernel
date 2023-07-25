using System.ComponentModel.DataAnnotations.Schema;

namespace Ardalis.SharedKernel;

/// <summary>
/// A base class for DDD Entities. Includes support for domain events dispatched post-persistence.
/// If you prefer GUID Ids, change it here.
/// If you need to support both GUID and int IDs, change to EntityBase&lt;TId&gt; and use TId as the type for Id.
/// </summary>
public abstract class EntityBase
{
  public int Id { get; set; }

  private List<DomainEventBase> _domainEvents = new();
  [NotMapped]
  public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
  internal void ClearDomainEvents() => _domainEvents.Clear();
}

