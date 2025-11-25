using RT.Comb;

namespace Ardalis.SharedKernel;

public class SequentialGuidGenerator(ICombProvider combProvider) : ISequentialGuidGenerator
{
  public Guid NewSequentialGuid()
  {
    var sqlCombProvider = (SqlCombProvider?)combProvider;

    return sqlCombProvider == null ? throw new Exception("sqlCombProvider is null") : sqlCombProvider.Create();
  }
}
