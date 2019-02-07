using NUnit.Framework;

namespace DDD.Policy.MethodInjection
{
  [TestFixture]
  public class PolicyTests
  {
    [Test]
    public void Publish_should_calculate_totalCost()
    {
      ICostCalculatorPolicy costCalculatorPolicy = CostCalculatorFactory.Create();
      Document document = new Document(10); //or _repository.Get(aggregateId)

      document.Publish(costCalculatorPolicy);

      //_repository.Save(document);
    }
  }
}