namespace Acme.SharedKernel;

public interface IHasDomainEvents
{
  IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
  void ClearDomainEvents();
}
