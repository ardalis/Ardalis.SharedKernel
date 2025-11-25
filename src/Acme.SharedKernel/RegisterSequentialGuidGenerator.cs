using Microsoft.Extensions.DependencyInjection;

namespace Acme.SharedKernel;
public static partial class ServiceCollectionExtensions
{
  public static IServiceCollection RegisterSequentialGuidGenerator(this IServiceCollection services)
  {
    services.AddSingleton<ISequentialGuidGenerator, SequentialGuidGenerator>();

    return services;
  }
}
