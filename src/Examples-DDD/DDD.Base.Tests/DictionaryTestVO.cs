using System.Collections.Generic;
using DDD.Base.Domain;

namespace DDD.Base.Tests
{
  public class DictionaryTestVO : ValueObject
  {
    Dictionary<string, TestVOStringWrapper> _items;
    
    public DictionaryTestVO(Dictionary<string, TestVOStringWrapper> items)
    {
      _items = items;      
    }
  }
}