namespace DDD.Base.Domain
{
  public interface IGenericRepository<T> where T : IUnpublishedEventsAccesor
  {
    T Get(int id);

    void Delete(T aggregateRoot);

    void Save(T agregateRoot);
  }
}