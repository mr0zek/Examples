using System.Collections.Generic;

namespace DDD.DomainEvents.DelayedPublishing
{
  public class AggregateRootWithEventList : IUnpublishedEventsAccesor
  {
    private readonly List<IDomainEvent> _eventsToPublish = new List<IDomainEvent>();
    public int Id { get; set; }

    protected void PublishEvent(IDomainEvent domainEvent)
    {
      _eventsToPublish.Add(domainEvent);
    }

    public IEnumerable<IDomainEvent> GetUnpublishedEvents()
    {
      return _eventsToPublish;
    }
  }
}