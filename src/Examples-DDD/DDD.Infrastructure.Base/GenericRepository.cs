using DDD.Base.Domain;
using NHibernate;

namespace DDD.Infrastructure.Base
{
  public class GenericRepository<TAggregateRoot> : IGenericRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
  {
    private readonly IDependencyInjector _dependencyInjector;
    private readonly ISession _session;
    private readonly IDomainEventPublisher _domainEventPublisher;

    public GenericRepository(ISession session, IDomainEventPublisher domainEventPublisher, IDependencyInjector dependencyInjector)
    {
      _session = session;
      _domainEventPublisher = domainEventPublisher;
      _dependencyInjector = dependencyInjector;
    }

    public TAggregateRoot Get(int id)
    {
      TAggregateRoot result = _session.Get<TAggregateRoot>(id);
      if (result == null)
      {
        return null;
      }
      if ((result as ISoftDeletable).IsRemoved())
      {
        return null;
      }
      _dependencyInjector.InjectDependencies(result);

      return result;
    }

    public void Delete(TAggregateRoot aggregateRoot)
    {
      (aggregateRoot as ISoftDeletable).MarkAsRemoved();
      _session.SaveOrUpdate(aggregateRoot);
      PublishEvents(aggregateRoot);
    }

    public void Save(TAggregateRoot aggregateRoot)
    {
      _session.SaveOrUpdate(aggregateRoot);
      PublishEvents(aggregateRoot);
    }

    private void PublishEvents(TAggregateRoot aggregateRoot)
    {
      var events = (aggregateRoot as IUnpublishedEventsAccesor).GetUnpublishedEvents();
      foreach (var domainEvent in events)
      {
        _domainEventPublisher.Publish(domainEvent);
      }
    }
  }
}