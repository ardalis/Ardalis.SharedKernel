//
// Copyright 2024 - Beakpoint Insights, Inc.
//
// This source code is protected under international copyright law. All rights reserved
// and protected by the copyright holders.
//
// This file is confidential and only available to authorized individuals with the
// permission of the copyright holders.
//
// Portions of this project are based on the work of Steve Smith (https://github.com/ardalis/Ardalis.SharedKernel) and his SharedKernel project.
//
using Beakpoint.SharedKernel;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace Beakpoint.SharedKernel.UnitTests.MediatRDomainEventDispatcherTests;

public class DispatchAndClearEvents {
    private class TestDomainEvent : DomainEventBase { }
    private class TestEntity : EntityBase {
        public void AddTestDomainEvent() {
            var domainEvent = new TestDomainEvent();
            RegisterDomainEvent(domainEvent);
        }
    }

    [Fact]
    public async void CallsPublishAndClearDomainEvents() {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var domainEventDispatcher = new MediatRDomainEventDispatcher(mediatorMock.Object);
        var entity = new TestEntity();
        entity.AddTestDomainEvent();

        // Act
        await domainEventDispatcher.DispatchAndClearEvents(new List<EntityBase> { entity });

        // Assert
        mediatorMock.Verify(m => m.Publish(It.IsAny<DomainEventBase>(), It.IsAny<CancellationToken>()), Times.Once);
        entity.DomainEvents.Should().BeEmpty();
    }
}
