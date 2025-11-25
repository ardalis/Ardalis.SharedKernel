namespace Ardalis.SharedKernel;

/// <summary>
/// Apply this marker interface to entities that should be audited
/// </summary>
public interface IAuditableEntity
{
  public DateTime CreatedOn { get; set; }
  public DateTime UpdatedOn { get; set; }
}
