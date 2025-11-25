using System.ComponentModel.DataAnnotations;

namespace Ardalis.SharedKernel;

public interface IConcurrencyEntity
{
  [ConcurrencyCheck]
  public int Version { get; set; }
}
