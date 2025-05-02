using Ardalis.Result;
using Xunit;

namespace Ardalis.SharedKernel.UnitTests.MediatRCqrsHandlersTests;
public class QueryHandlers
{
  /// <summary>
  /// This can and should be the strongly typed domain concepts representing the
  /// ID of the entity. This is a simple example using an int without , 
  /// but you can use <see href="https://github.com/SteveDunn/Vogen">Vogen</see> or similar solution 
  /// </summary>
  private readonly record struct SomeId(int Value);
  private record SampleEntityDto(string Data);
  private record GetByIdQuery(SomeId EntityId) : IQuery<SampleEntityDto>;
  private class GetSampleDataQueryHandler : IQueryHandler<GetByIdQuery, SampleEntityDto>
  {
    public async Task<Result<SampleEntityDto>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
      await Task.Delay(1, cancellationToken);

      if (query.EntityId == new SomeId(0))
        return Result.Result.Error("Invalid ID");

      return Result.Result.Success(new SampleEntityDto(Data: $"Sample Data for ID {query.EntityId.Value}"));
    }
  }
  [Fact]
  public async Task QueryHandler_CorrectId_ReturnsEntitySuccessfully()
  {
    // Arrange
    var query = new GetByIdQuery(new SomeId(1));
    var handler = new GetSampleDataQueryHandler();

    // Act
    var result = await handler.Handle(query, CancellationToken.None);

    // Assert
    Assert.True(result.IsSuccess);
    Assert.Equal("Sample Data for ID 1", result.Value.Data);
  }

  [Fact]
  public async Task QueryHandler_InvalidId_ReturnsError()
  {
    // Arrange
    var query = new GetByIdQuery(new SomeId(0));
    var handler = new GetSampleDataQueryHandler();

    // Act
    var result = await handler.Handle(query, CancellationToken.None);

    // Assert
    Assert.False(result.IsSuccess);
    Assert.Contains("Invalid ID", result.Errors);
  }
}
