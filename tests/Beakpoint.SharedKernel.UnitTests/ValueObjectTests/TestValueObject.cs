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

namespace Beakpoint.SharedKernel.UnitTests.ValueObjectTests;

public class TestValueObject(int value) : ValueObject {
    public int Value { get; } = value;

    protected override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}
