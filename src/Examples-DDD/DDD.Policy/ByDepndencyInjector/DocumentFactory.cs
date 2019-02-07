using DDD.Base.Domain;

namespace DDD.Policy.ByDepndencyInjector
{
  public class DocumentFactory : IDocumentFactory
  {
    private IDependencyInjector _dependencyInjector;

    public DocumentFactory(IDependencyInjector dependencyInjector)
    {
      _dependencyInjector = dependencyInjector;
    }

    public Document2 Create(int pagesCount)
    {
      Document2 result = new Document2(pagesCount);
      _dependencyInjector.InjectDependencies(result);
      return result;
    }
  }
}