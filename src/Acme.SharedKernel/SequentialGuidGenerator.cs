namespace Acme.SharedKernel;

public class SequentialGuidGenerator() : ISequentialGuidGenerator
{
  public Guid NewSequentialGuid()
  {
    return System.Guid.CreateVersion7();
  }
}
