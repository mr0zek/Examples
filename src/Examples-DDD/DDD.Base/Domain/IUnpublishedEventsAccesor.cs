using System.Collections.Generic;

namespace DDD.Base.Domain
{
  public interface IUnpublishedEventsAccesor
  {
    IEnumerable<IDomainEvent> GetUnpublishedEvents();
  }
}