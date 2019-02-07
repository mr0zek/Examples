using DDD.Base.Domain;
using DDD.Examples.Common;

namespace DDD.Policy.ByDepndencyInjector
{
  public class Document2 : AggregateRoot
  {
    private int _pages;
    private ICostCalculatorPolicy _costCalculatorPolicy;

    public Document2(int pages)
    {
      _pages = pages;
      _status = DocumentStatus.NEW;
    }

    public void Publish()
    {
      _status = DocumentStatus.PUBLISHED;

      _printingCost = _costCalculatorPolicy.Calculate(_pages);
    }

    private Money _printingCost;

    private DocumentStatus _status;
  }
}