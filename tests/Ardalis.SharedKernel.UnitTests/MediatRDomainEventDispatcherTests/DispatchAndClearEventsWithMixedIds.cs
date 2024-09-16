using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Ardalis.SharedKernel.UnitTests.MediatRDomainEventDispatcherTests;

public class DispatchAndClearEventsWithMixedIds
{
  private class TestDomainEvent : DomainEventBase { }
  public readonly record struct StronglyTyped { }

  private class TestEntity : EntityBase
  {
    public void AddTestDomainEvent()
    {
      TestDomainEvent domainEvent = new();
      RegisterDomainEvent(domainEvent);
    }
  }
  private class TestEntityGuid : EntityBase<Guid>
  {
    public void AddTestDomainEvent()
    {
      TestDomainEvent domainEvent = new();
      RegisterDomainEvent(domainEvent);
    }
  }
  private class TestEntityStronglyTyped : EntityBase<StronglyTyped>
  {
    public void AddTestDomainEvent()
    {
      TestDomainEvent domainEvent = new();
      RegisterDomainEvent(domainEvent);
    }
  }

  [Fact]
  public async void CallsPublishAndClearDomainEventsWithStronglyTypedId()
  {
    // Arrange
    var mediatorMock = new Mock<IMediator>();
    var domainEventDispatcher = new MediatRDomainEventDispatcher(mediatorMock.Object, NullLogger<MediatRDomainEventDispatcher>.Instance);
    var entity = new TestEntity();
    var entityGuid = new TestEntityGuid();
    var entityStronglyTyped = new TestEntityStronglyTyped();
    entity.AddTestDomainEvent();
    entityGuid.AddTestDomainEvent();
    entityStronglyTyped.AddTestDomainEvent();

    // Act
    await domainEventDispatcher.DispatchAndClearEvents(new List<IHasDomainEvents> { entity, entityGuid, entityStronglyTyped });

    // Assert
    mediatorMock.Verify(m => m.Publish(It.IsAny<DomainEventBase>(), It.IsAny<CancellationToken>()), Times.Exactly(3));
    entity.DomainEvents.Should().BeEmpty();
    entityGuid.DomainEvents.Should().BeEmpty();
    entityStronglyTyped.DomainEvents.Should().BeEmpty();
  }
}
