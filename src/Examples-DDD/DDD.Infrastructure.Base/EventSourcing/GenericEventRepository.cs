using DDD.Base.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infrastructure.Base.EventSourcing
{
  public class GenericEventRepository<T> : IGenericEventRepository<T>
    where T : AggregateRootForEventStore, IHaveEvents, new()
  {
    private ISession _session;
    private IEventSerializer _serializer;

    public GenericEventRepository(ISession session, IEventSerializer serializer)
    {
      _session = session;
      _serializer = serializer;
    }

    public T Load(int id)
    {
      IList<Event> result = _session.QueryOver<Event>().Where(f => f.AggregateId == id).List();
      IEnumerable<IDomainEvent> domainEvents = result.Select(f => _serializer.Deserialize(Type.GetType(f.Type, true), f.Data));
      T o = new T();
      o.LoadFromHistory(domainEvents);
      return o;
    }

    public void Delete(int id)
    {
      T o = Load(id);
      o.MarkAsRemoved();
      Save(o);
    }

    public void Save(T entity)
    {
      var events = entity.GetEvents();
      int version = entity.Version + 1;
      foreach (IDomainEvent domainEvent in events)
      {
        _session.SaveOrUpdate(new Event(entity.Id, domainEvent.GetType().AssemblyQualifiedName, _serializer.Serialize(domainEvent), version));
        version++;
      }
    }
  }
}