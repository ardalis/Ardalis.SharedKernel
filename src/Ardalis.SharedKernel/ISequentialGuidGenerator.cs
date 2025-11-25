namespace Ardalis.SharedKernel;

/// <summary>
/// Used to generate new sequential GUIDs for SQL Server to reduce fragmentation.
/// </summary>
public interface ISequentialGuidGenerator
{
  Guid NewSequentialGuid();
}
