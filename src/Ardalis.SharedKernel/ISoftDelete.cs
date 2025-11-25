namespace Ardalis.SharedKernel;

/// <summary>
/// Apply this marker interface to entities that should be soft deleted
/// </summary>
public interface ISoftDelete
{
  public DateTime? DeletedOn { get; set; }
}
