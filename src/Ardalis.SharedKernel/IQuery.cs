using Ardalis.Result;
using MediatR;

namespace Ardalis.SharedKernel;

/// <summary>
/// Source: https://code-maze.com/cqrs-mediatr-fluentvalidation/
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
