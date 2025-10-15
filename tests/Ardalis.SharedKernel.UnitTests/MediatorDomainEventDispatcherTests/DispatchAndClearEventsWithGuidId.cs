using Mediator;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Ardalis.SharedKernel.UnitTests.MediatRDomainEventDispatcherTests;

public class DispatchAndClearEventsWithGuidId : IDomainEventHandler<DispatchAndClearEventsWithGuidId.TestDomainEvent>
{
  public class TestDomainEvent : DomainEventBase { }
  private class TestEntity : EntityBase<Guid>
  {
    public void AddTestDomainEvent()
    {
      var domainEvent = new TestDomainEvent();
      RegisterDomainEvent(domainEvent);
    }
  }

  [Fact]
  public async Task CallsPublishAndClearDomainEvents()
  {
    // Arrange
    var mediatorMock = new Mock<IMediator>();
    var domainEventDispatcher = new MediatorDomainEventDispatcher(mediatorMock.Object, NullLogger<MediatorDomainEventDispatcher>.Instance);
    var entity = new TestEntity();
    entity.AddTestDomainEvent();

    // Act
    await domainEventDispatcher.DispatchAndClearEvents(new List<EntityBase<Guid>> { entity });

    // Assert
    mediatorMock.Verify(m => m.Publish(It.IsAny<IDomainEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    entity.DomainEvents.Should().BeEmpty();
  }

  public ValueTask Handle(DispatchAndClearEventsWithGuidId.TestDomainEvent notification, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
