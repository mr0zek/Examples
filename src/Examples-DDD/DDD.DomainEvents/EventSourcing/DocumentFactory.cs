using DDD.Base.Domain;

namespace DDD.DomainEvents.EventSourcing
{
  public class DocumentFactory : IDocumentFactory
  {
    public Document3 Create(int id)
    {
      return new Document3(id);
    }
  }
}