namespace DDD.Infrastructure.Base
{
  public interface ISystemEventPublisher
  {
    void Publish<T>(T @event) where T : ISystemEvent;
  }
}