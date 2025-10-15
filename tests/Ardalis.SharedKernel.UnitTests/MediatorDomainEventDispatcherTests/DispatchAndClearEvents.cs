﻿using Mediator;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace Ardalis.SharedKernel.UnitTests.MediatorDomainEventDispatcherTests;

public class DispatchAndClearEvents : INotificationHandler<DispatchAndClearEvents.TestDomainEvent>
{
  public class TestDomainEvent : DomainEventBase { }
  private class TestEntity : EntityBase
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
    await domainEventDispatcher.DispatchAndClearEvents(new List<EntityBase> { entity });

    // Assert
    mediatorMock.Verify(m => m.Publish(It.IsAny<DomainEventBase>(), It.IsAny<CancellationToken>()), Times.Once);
    entity.DomainEvents.Should().BeEmpty();
  }

  public ValueTask Handle(TestDomainEvent notification, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
