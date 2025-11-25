using Microsoft.Extensions.DependencyInjection;
using RT.Comb;
using RT.Comb.AspNetCore;

namespace Ardalis.SharedKernel;
public static partial class ServiceCollectionExtensions
{
  public static IServiceCollection RegisterSequentialGuidGenerator(this IServiceCollection services)
  {
    var utcNoRepeatTimestampProvider = new UtcNoRepeatTimestampProvider { IncrementMs = 2 };
    services.AddSqlCombGuidWithUnixDateTime(utcNoRepeatTimestampProvider.GetTimestamp);

    services.AddSingleton<ISequentialGuidGenerator, SequentialGuidGenerator>();

    return services;
  }
}
