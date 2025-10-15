using Mediator;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Ardalis.SharedKernel.UnitTests.MediatRDomainEventDispatcherTests;

public class DispatchAndClearEventsWithStronglyTypedIds : INotificationHandler<DispatchAndClearEventsWithStronglyTypedIds.TestDomainEvent>
{
  public class TestDomainEvent : DomainEventBase { }

  public readonly record struct StronglyTyped { }

  private class TestEntityStronglyTyped : EntityBase<StronglyTyped>
  {
    public void AddTestDomainEvent()
    {
      TestDomainEvent domainEvent = new();
      RegisterDomainEvent(domainEvent);
    }
  }

  [Fact]
  public async Task CallsPublishAndClearDomainEventsWithStronglyTypedId()
  {
    // Arrange
    Mock<IMediator> mediatorMock = new Mock<IMediator>();
    MediatorDomainEventDispatcher domainEventDispatcher =
      new(mediatorMock.Object, NullLogger<MediatorDomainEventDispatcher>.Instance);
    TestEntityStronglyTyped entity = new();
    entity.AddTestDomainEvent();

    // Act
    await domainEventDispatcher.DispatchAndClearEvents(new List<IHasDomainEvents> { entity });

    // Assert
    mediatorMock.Verify(m => m.Publish(It.IsAny<DomainEventBase>(), It.IsAny<CancellationToken>()), Times.Once);
    entity.DomainEvents.Should().BeEmpty();
  }

  public ValueTask Handle(TestDomainEvent notification, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
