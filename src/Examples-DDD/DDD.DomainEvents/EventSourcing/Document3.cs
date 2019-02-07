using DDD.Base.Domain;
using System;
using System.Collections.Generic;

namespace DDD.DomainEvents.EventSourcing
{
  public class Document3 : AggregateRootForEventStore
  {
    public enum DocumentStatus
    {
      New,
      Accepted
    }

    private DocumentStatus _status;

    public void Accept()
    {
      ApplyChange(new DocumentAccepted(Id));
    }

    private void Apply(DocumentAccepted documentAccepted)
    {
      _status = DocumentStatus.Accepted;
    }

    private void Apply(DocumentCreated documentCreated)
    {
      _status = DocumentStatus.New;
      Id = documentCreated.Id;
    }

    public Document3(int id) : base(id)
    {
      ApplyChange(new DocumentCreated(id));
    }

    public Document3()
    {
    }
  }
}