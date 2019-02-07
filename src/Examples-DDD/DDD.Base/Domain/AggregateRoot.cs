using System;
using System.Collections.Generic;

namespace DDD.Base.Domain
{
  public abstract class AggregateRoot : IUnpublishedEventsAccesor, ISoftDeletable
  {
    public int Id { get; protected set; }
    private List<IDomainEvent> _unpublishedEvents = new List<IDomainEvent>();
    private bool _isRemoved;

    protected AggregateRoot()
    {
    }

    IEnumerable<IDomainEvent> IUnpublishedEventsAccesor.GetUnpublishedEvents()
    {
      return _unpublishedEvents;
    }

    public void PublishEvent(IDomainEvent @event)
    {
      _unpublishedEvents.Add(@event);
    }

    bool ISoftDeletable.IsRemoved()
    {
      return _isRemoved;
    }

    public virtual void MarkAsRemoved()
    {
      _isRemoved = true;
    }
  }
}