using Mediator;

namespace Ardalis.SharedKernel.UnitTests.DomainEventBaseTests;

public class DomainEventBase_Constructor : INotificationHandler<DomainEventBase_Constructor.TestDomainEvent>
{
  public class TestDomainEvent : DomainEventBase { }

  [Fact]
  public void SetsDateOccurredToCurrentDateTime()
  {
    // Arrange
    var beforeCreation = DateTime.UtcNow;

    // Act
    var domainEvent = new TestDomainEvent();

    // Assert
    domainEvent.DateOccurred.Should().BeOnOrAfter(beforeCreation);
    domainEvent.DateOccurred.Should().BeOnOrBefore(DateTime.UtcNow);
  }

  public ValueTask Handle(TestDomainEvent notification, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
