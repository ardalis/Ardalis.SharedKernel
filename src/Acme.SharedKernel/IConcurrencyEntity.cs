using System.ComponentModel.DataAnnotations;

namespace Acme.SharedKernel;

public interface IConcurrencyEntity
{
  [ConcurrencyCheck]
  public int Version { get; set; }
}
