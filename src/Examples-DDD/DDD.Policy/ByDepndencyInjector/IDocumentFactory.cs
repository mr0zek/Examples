namespace DDD.Policy.ByDepndencyInjector
{
  public interface IDocumentFactory
  {
    Document2 Create(int pagesCount);
  }
}