using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DDD.Base.Domain;
using DDD.Infrastructure.Base;
using NUnit.Framework;
using System.Runtime.Remoting.Messaging;

namespace DDD.Policy.ByDepndencyInjector
{
  [TestFixture]
  public class PolicyTests
  {
    [Test]
    public void Publish_should_calculate_totalCost()
    {
      IWindsorContainer windsorContainer = new WindsorContainer();
      windsorContainer.Register(Component.For<IDependencyInjector>().ImplementedBy<DependencyInjector>());
      windsorContainer.Register(Component.For<IDocumentFactory>().ImplementedBy<DocumentFactory>());
      windsorContainer.Register(Component.For<ICostCalculatorPolicy>().UsingFactoryMethod(CostCalculatorFactory.Create));
      windsorContainer.Register(Component.For<IWindsorContainer>().Instance(windsorContainer));

      Document2 document = windsorContainer.Resolve<IDocumentFactory>().Create(10);

      Assert.DoesNotThrow(() => document.Publish());

      //_repository.Save(document);
    }
  }
}