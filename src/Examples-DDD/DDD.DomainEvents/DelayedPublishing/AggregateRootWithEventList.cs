using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using DDD.Base.Domain;

namespace DDD.DomainEvents.DelayedPublishing
{
  public class AggregateRootWithEventList : IUnpublishedEventsAccesor
  {
    private readonly List<IDomainEvent> _eventsToPublish = new EditableList<IDomainEvent>();
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