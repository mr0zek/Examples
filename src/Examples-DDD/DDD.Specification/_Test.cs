using NUnit.Framework;
using System;
using DDD.Base.SharedKernel.Specification;

namespace DDD.Specification
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void RockersSpecificationExample()
    {
      ISpecification<User> grandpaRockersSpecification =
        new GenderSpecification(Gender.Male)
          .And(new AgeSpecification(60, 100))
          .And(new BikeSpecification(MotorbikeType.Suzuki).Not())
          .And(
            new BikeSpecification(MotorbikeType.HarleyDavidson)
              .Or(new BikeSpecification(MotorbikeType.Honda)));

      bool result = grandpaRockersSpecification.IsSatisfiedBy(GetCurrentUser());

      Assert.IsTrue(result);
    }

    private User GetCurrentUser()
    {
      return new User() { Age = 80, Gender = Gender.Male, MotorbikeType = MotorbikeType.HarleyDavidson };
    }
  }
}