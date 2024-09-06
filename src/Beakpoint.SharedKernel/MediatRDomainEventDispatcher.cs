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
using System;
using MediatR;

namespace Beakpoint.SharedKernel;

public class MediatRDomainEventDispatcher : IDomainEventDispatcher {
    private readonly IMediator _mediator;

    public MediatRDomainEventDispatcher(IMediator mediator) {
        _mediator = mediator;
    }

    public async Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents) {
        foreach (var entity in entitiesWithEvents) {
            var events = entity.DomainEvents.ToArray();
            entity.ClearDomainEvents();
            foreach (var domainEvent in events) {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }
    }

    public async Task DispatchAndClearEvents<TId>(IEnumerable<EntityBase<TId>> entitiesWithEvents)
      where TId : struct, IEquatable<TId> {
        foreach (var entity in entitiesWithEvents) {
            var events = entity.DomainEvents.ToArray();
            entity.ClearDomainEvents();
            foreach (var domainEvent in events) {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }
    }
}

