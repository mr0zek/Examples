namespace DDD.DomainEvents.EventSourcing
{
  internal interface IDocumentFactory
  {
    Document3 Create(int id);
  }
}