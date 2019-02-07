using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DDD.Infrastructure.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Tests
{
  [TestFixture]
  public class DependencyInjectorTests
  {
    [Test]
    public void InjectDepndecy_for_all_dependencies()
    {
      IWindsorContainer container = new WindsorContainer();
      container.Register(Component.For<IPolicy>().ImplementedBy<Policy>());

      Document d = new Document();
      DependencyInjector dependencyInjector = new DependencyInjector(container);

      dependencyInjector.InjectDependencies(d);

      Assert.IsNotNull(d.GetPolicy());
    }

    [Test]
    public void InjectDepndecy_for_single_dependency()
    {
      Document d = new Document();
      DependencyInjector.InjectDependency(d, new Policy());

      Assert.IsNotNull(d.GetPolicy());
    }
  }
}