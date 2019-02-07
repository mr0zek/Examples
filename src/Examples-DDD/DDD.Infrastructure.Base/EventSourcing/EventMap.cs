using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace DDD.Infrastructure.Base.EventSourcing
{
  public class EventMap : ClassMapping<Event>
  {
    public EventMap()
    {
      Id(f => f.Id, m => m.Generator(Generators.Identity));
      Property(f => f.AggregateId);
      Property(f => f.Type);
      Property(f => f.Data);
      Property(f => f.Version);
    }
  }
}