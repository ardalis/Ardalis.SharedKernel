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
using Xunit;
using FluentAssertions;
using Beakpoint.SharedKernel;

namespace Beakpoint.SharedKernel.UnitTests.DomainEventBaseTests;

public class DomainEventBase_Constructor {
    private class TestDomainEvent : DomainEventBase { }

    [Fact]
    public void SetsDateOccurredToCurrentDateTime() {
        // Arrange
        var beforeCreation = DateTime.UtcNow;

        // Act
        var domainEvent = new TestDomainEvent();

        // Assert
        domainEvent.DateOccurred.Should().BeOnOrAfter(beforeCreation);
        domainEvent.DateOccurred.Should().BeOnOrBefore(DateTime.UtcNow);
    }
}
