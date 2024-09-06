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
using FluentAssertions;
using Xunit;

namespace Beakpoint.SharedKernel.UnitTests.ValueObjectTests;
public class ValueObject_HashEquality {
    [Fact]
    public void WithSameValuesHaveSameHashCode() {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(1);

        // Act & Assert
        valueObject1.GetHashCode().Should().Be(valueObject2.GetHashCode());
    }

    [Fact]
    public void WithDifferentValuesAreNotEqual() {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(2);

        // Act & Assert
        valueObject1.Should().NotBe(valueObject2);
    }
}
