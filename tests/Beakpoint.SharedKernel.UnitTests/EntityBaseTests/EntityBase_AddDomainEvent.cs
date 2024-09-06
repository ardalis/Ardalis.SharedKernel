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
using Xunit;

namespace Beakpoint.SharedKernel.UnitTests.EntityBaseTests;

public class EntityBase_AddDomainEvent {
    private class TestDomainEvent : DomainEventBase { }

    private class TestEntity : EntityBase {
        public void AddTestDomainEvent() {
            var domainEvent = new TestDomainEvent();
            RegisterDomainEvent(domainEvent);
        }
    }

    [Fact]
    public void AddsDomainEventToEntity() {
        // Arrange
        var entity = new TestEntity();

        // Act
        entity.AddTestDomainEvent();

        // Assert
        entity.DomainEvents.Should().HaveCount(1);
        entity.DomainEvents.Should().AllBeOfType<TestDomainEvent>();
    }
}
