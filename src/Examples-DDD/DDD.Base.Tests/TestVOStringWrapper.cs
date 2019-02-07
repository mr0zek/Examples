using DDD.Base.Domain;

namespace DDD.Base.Tests
{
  public class TestVOStringWrapper : ValueObject
  {
    private string _value;

    public TestVOStringWrapper(string value)
    {
      _value = value;
    }

    public static implicit operator TestVOStringWrapper(string value)
    {
      return new TestVOStringWrapper(value);
    }

    public static implicit operator string(TestVOStringWrapper value)
    {
      if (value != null)
      {
        return value._value;
      }
      return null;
    }

    public override string ToString()
    {
      return _value;
    }
  }
}