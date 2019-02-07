using DDD.Base.Domain;
using System;
using System.IO;
using System.Xml.Serialization;

namespace DDD.Infrastructure.Base.EventSourcing
{
  public class EventSerializer : IEventSerializer
  {
    public IDomainEvent Deserialize(Type type, string data)
    {
      using (StringReader sr = new StringReader(data))
      {
        return new XmlSerializer(type).Deserialize(sr) as IDomainEvent;
      }
    }

    public string Serialize(IDomainEvent domainEvent)
    {
      using (StringWriter sr = new StringWriter())
      {
        new XmlSerializer(domainEvent.GetType()).Serialize(sr, domainEvent);
        return sr.GetStringBuilder().ToString();
      }
    }
  }
}