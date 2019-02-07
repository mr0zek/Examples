namespace DDD.Policy
{
  public class CostCalculatorFactory
  {
    public static ICostCalculatorPolicy Create()
    {
      string value = System.Configuration.ConfigurationManager.AppSettings["KindOfPrints"];
      if (value == "BW")
      {
        return new BWCostCalculator();
      }
      else
      {
        return new ColorCostCalculator();
      }
    }
  }
}