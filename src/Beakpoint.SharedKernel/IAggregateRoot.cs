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
namespace Beakpoint.SharedKernel;

/// <summary>
/// Apply this marker interface only to aggregate root entities in your domain model
/// Your repository implementation can use constraints to ensure it only operates on aggregate roots
/// </summary>
public interface IAggregateRoot { }
