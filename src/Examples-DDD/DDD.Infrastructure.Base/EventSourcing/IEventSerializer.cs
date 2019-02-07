using System;
using DDD.Base.Domain;

namespace DDD.Infrastructure.Base.EventSourcing
{
  public interface IEventSerializer
  {
    IDomainEvent Deserialize(Type type, string data);
    string Serialize(IDomainEvent domainEvent);
  }
}