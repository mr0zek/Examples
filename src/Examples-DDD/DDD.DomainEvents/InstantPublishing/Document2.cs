using DDD.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.DomainEvents.DelayedPublishing;

namespace DDD.DomainEvents.InstantPublishing
{
  public class Document2 : AggregateRootWithEventPublisher
  {
    public enum DocumentStatus
    {
      New,
      Accepted
    }

    private DocumentStatus _status;

    public Document2()
    {
    }

    public void Accept()
    {
      _status = DocumentStatus.Accepted;
      EventPublisher.Publish(new DocumentAccepted(Id));
    }
  }
}