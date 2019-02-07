using DDD.Base.Domain;

namespace DDD.Infrastructure.Tests
{
  public class Document : AggregateRoot
  {
    IPolicy _myPolicy;

    public IPolicy GetPolicy()
    {
      return _myPolicy;
    }
  }
}