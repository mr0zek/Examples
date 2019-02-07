using System.Collections.Generic;
using System.Linq;
using DDD.Base.Domain;

namespace DDD.Base.Tests
{
  public class EnumerableTestVO : ValueObject
  {
    IEnumerable<TestVOStringWrapper> _items;
    TestVOStringWrapper[] _array;
    List<object> _list;
    
    public EnumerableTestVO(IEnumerable<TestVOStringWrapper> items)
    {
      _items = items;
      _array = items.ToArray();
      _list = items.ToList<object>();
    }
  }
}