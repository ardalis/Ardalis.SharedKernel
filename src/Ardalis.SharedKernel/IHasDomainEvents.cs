namespace Ardalis.SharedKernel;

public interface IHasDomainEvents
{
  IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
  void ClearDomainEvents();
}
