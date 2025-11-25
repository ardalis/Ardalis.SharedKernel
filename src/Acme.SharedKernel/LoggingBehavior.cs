using System.Diagnostics;
using System.Reflection;
using Ardalis.GuardClauses;
using Mediator;
using Microsoft.Extensions.Logging;

namespace Ardalis.SharedKernel;

/// <summary>
/// Adds logging for all requests in Mediator pipeline.
/// Configure by adding the service with a scoped lifetime
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
  : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
  private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger = logger;

  public async ValueTask<TResponse> Handle(
      TRequest request,
      MessageHandlerDelegate<TRequest, TResponse> next,
      CancellationToken cancellationToken)
  {
    Guard.Against.Null(request);
    
    if (_logger.IsEnabled(LogLevel.Information))
    {
      _logger.LogInformation("Handling {RequestName} with {@Request}", typeof(TRequest).Name, request);
    }

    var sw = Stopwatch.StartNew();

    var response = await next(request, cancellationToken);

    sw.Stop();
    
    if (_logger.IsEnabled(LogLevel.Information))
    {
      _logger.LogInformation("Handled {RequestName} with {Response} in {ElapsedMilliseconds} ms", 
        typeof(TRequest).Name, response, sw.ElapsedMilliseconds);
    }
    
    return response;
  }
}
