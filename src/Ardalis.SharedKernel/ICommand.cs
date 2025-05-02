using Ardalis.Result;
using MediatR;

namespace Ardalis.SharedKernel;

/// <summary>
/// Source: https://code-maze.com/cqrs-mediatr-fluentvalidation/
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
public interface ICommand : ICommand<Unit>;
