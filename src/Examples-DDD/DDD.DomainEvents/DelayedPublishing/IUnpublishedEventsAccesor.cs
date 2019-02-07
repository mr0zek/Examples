using System.Collections.Generic;
using DDD.Base.Domain;

namespace DDD.DomainEvents.DelayedPublishing
{
  public interface IUnpublishedEventsAccesor
  {
    IEnumerable<IDomainEvent> GetUnpublishedEvents();
  }
}