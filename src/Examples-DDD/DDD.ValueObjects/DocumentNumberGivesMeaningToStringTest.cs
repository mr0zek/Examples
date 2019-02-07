using DDD.Examples.Common;
using NUnit.Framework;
using System;

namespace DDD.ValueObjects
{
  [TestFixture]
  public class DocumentNumberGivesMeaningToStringTest
  {
    [Test]
    public void Equals_operator_should_work_for_equal_objects()
    {
      DocumentNumber documentNumber = "DN/1";
      DocumentNumber documentNumber2 = "DN/1";

      Assert.IsTrue(documentNumber == documentNumber2);
    }

    [Test]
    public void Equals_operator_should_work_for_not_equal_objects()
    {
      DocumentNumber documentNumber = "DN/1";
      DocumentNumber documentNumber2 = "DN/2";

      Assert.IsFalse(documentNumber == documentNumber2);
    }

    [Test]
    public void Equals_operator_should_work_for_equal_object_to_string()
    {
      DocumentNumber documentNumber = "DN/1";
      string documentNumber2 = "DN/1";

      Assert.IsTrue(documentNumber == documentNumber2);
    }

    [Test]
    public void Equals_operator_should_work_for_not_equal_object_to_string()
    {
      DocumentNumber documentNumber = "DN/1";
      string documentNumber2 = "DN/2";

      Assert.IsFalse(documentNumber == documentNumber2);
    }

    [Test]
    public void Equals_operator_should_work_for_inner_list()
    {
      DocumentNumber documentNumber = "DN/1";
      string documentNumber2 = "DN/2";

      Assert.IsFalse(documentNumber == documentNumber2);
    }
  }
}