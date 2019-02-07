using DDD.Base.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DDD.DomainEvents.InstantPublishing
{
  public class AggregateRootWithEventPublisher
  {
    public int Id { get; set; }

    protected IDomainEventPublisher EventPublisher { get; private set; }
  }
}