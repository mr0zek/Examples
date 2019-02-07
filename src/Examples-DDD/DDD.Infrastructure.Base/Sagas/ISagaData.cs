using Automatonymous;

namespace DDD.Infrastructure.Base.Sagas
{
  public interface ISagaData
  {
    State CurrentState { get; set; }
  }
}