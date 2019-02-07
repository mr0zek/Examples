namespace DDD.Base.Domain
{
  public interface IGenericEventRepository<T> where T : AggregateRootForEventStore, IHaveEvents, new()
  {
    T Load(int id);

    void Delete(int id);

    void Save(T entity);
  }
}