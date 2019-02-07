using System.Collections.Generic;
using NUnit.Framework;

namespace DDD.Base.Tests
{
  [TestFixture]
  public class ValueObjectGivesMeaningToString
  {
    [Test]
    public void Equals_operator_should_work_for_inner_list()
    {
      EnumerableTestVO test = new EnumerableTestVO(new TestVOStringWrapper[]{ "as1", "234" });
      EnumerableTestVO test2 = new EnumerableTestVO(new TestVOStringWrapper[] { "as1", "234" });
      EnumerableTestVO test3 = new EnumerableTestVO(new TestVOStringWrapper[] { "as1", "2341" });
      EnumerableTestVO test4 = new EnumerableTestVO(new TestVOStringWrapper[] { "as1" });
      
      Assert.AreEqual(test, test2);
      Assert.AreEqual(test2, test);

      Assert.AreNotEqual(test, test3);
      Assert.AreNotEqual(test3, test);

      Assert.AreNotEqual(test, test4);
      Assert.AreNotEqual(test4, test);      
    }

    [Test]
    public void Equals_operator_should_work_for_inner_dictionary()
    {
      DictionaryTestVO test = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as1", "234" }});
      DictionaryTestVO test2 = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as1", "234" } });
      DictionaryTestVO test3 = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as1", "2341" } });
      DictionaryTestVO test4 = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as1", "234" }, { "as2", "234" } });
      DictionaryTestVO test5 = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as11", "234" } });

      Assert.AreEqual(test, test2);
      Assert.AreEqual(test2, test);

      Assert.AreNotEqual(test, test3);
      Assert.AreNotEqual(test3, test);

      Assert.AreNotEqual(test, test4);
      Assert.AreNotEqual(test4, test);

      Assert.AreNotEqual(test, test5);
      Assert.AreNotEqual(test5, test);
    }
  }
}