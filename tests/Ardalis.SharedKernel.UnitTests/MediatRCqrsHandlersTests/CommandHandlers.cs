using Ardalis.Result;
using MediatR;
using Xunit;

namespace Ardalis.SharedKernel.UnitTests.MediatRCqrsHandlersTests;
public class CommandHandlers
{
  private record ChangeNameTestCommand(string Name) : ICommand;
  private class ChangeNameTestCommandHandler : ICommandHandler<ChangeNameTestCommand, Unit>
  {
    public async Task<Result<Unit>> Handle(ChangeNameTestCommand command, CancellationToken cancellationToken)
    {
      await Task.Delay(1, cancellationToken);
      if (string.IsNullOrEmpty(command.Name))
        return Result.Result.Error("Name cannot be empty");

      return Result.Result.Success();
    }
  }

  /// <summary>
  /// This can and should be the strongly typed domain concepts representing the
  /// ID of the entity. This is a simple example using an int, 
  /// but you can use <see href="https://github.com/SteveDunn/Vogen">Vogen</see> or similar solution 
  /// </summary>
  private readonly record struct SomeId(int Id);
  private record CreateEntityTestCommand(string Description) : ICommand<SomeId>;
  private class CreateEntityTestCommandHandler : ICommandHandler<CreateEntityTestCommand, SomeId>
  {
    public async Task<Result<SomeId>> Handle(CreateEntityTestCommand command, CancellationToken cancellationToken)
    {
      await Task.Delay(1, cancellationToken);
      if (string.IsNullOrEmpty(command.Description))
        return Result.Result.Error("Description cannot be empty");

      return Result.Result.Success(new SomeId(1));
    }
  }

  [Fact]
  public async Task ChangeNameTestCommandHandler_ValidName_HandlesSuccessfully()
  {
    // Arrange
    var command = new ChangeNameTestCommand(Name: "Test");
    var handler = new ChangeNameTestCommandHandler();
    // Act
    var result = await handler.Handle(command, CancellationToken.None);
    // Assert
    Assert.True(result.IsSuccess);
  }

  [Fact]
  public async Task ChangeNameTestCommandHandler_EmptyString_HandlesWithError()
  {
    // Arrange
    var command = new ChangeNameTestCommand(Name: "");
    var handler = new ChangeNameTestCommandHandler();
    // Act
    var result = await handler.Handle(command, CancellationToken.None);
    // Assert
    Assert.False(result.IsSuccess);
    Assert.True(result.IsError());
    Assert.Contains("Name cannot be empty", result.Errors);
  }

  [Fact]
  public async Task CreateEntityTestCommandHandler_ValidDescription_HandlesSuccessfully()
  {
    // Arrange
    var expectedId = new SomeId(1);
    var command = new CreateEntityTestCommand(Description: "Test");
    var handler = new CreateEntityTestCommandHandler();
    // Act
    var result = await handler.Handle(command, CancellationToken.None);
    // Assert
    Assert.True(result.IsSuccess);
    Assert.Equal(expectedId, result.Value);
  }

  [Fact]
  public async Task CreateTestCommandHandler_HandlesCommandWithError()
  {
    // Arrange
    var command = new CreateEntityTestCommand(Description: "");
    var handler = new CreateEntityTestCommandHandler();
    // Act
    var result = await handler.Handle(command, CancellationToken.None);
    // Assert
    Assert.False(result.IsSuccess);
    Assert.True(result.IsError());
    Assert.Contains("Description cannot be empty", result.Errors);
  }
}
