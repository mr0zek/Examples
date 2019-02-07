using System.Collections.Generic;

namespace DDD.Base.Domain
{
  public interface IHaveEvents
  {
    void LoadFromHistory(IEnumerable<IDomainEvent> events);

    IEnumerable<IDomainEvent> GetEvents();
  }
}