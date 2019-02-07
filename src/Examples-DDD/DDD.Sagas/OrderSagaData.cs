using Automatonymous;
using DDD.Infrastructure.Base.Sagas;

namespace DDD.Sagas
{
  public class OrderSagaData : ISagaData
  {
    public State CurrentState { get; set; }
    public string DocumentId { get; set; }
  }
}