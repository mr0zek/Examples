using DDD.DomainEvents.DelayedPublishing;
using DDD.Infrastructure.Base;
using NUnit.Framework;
using System.Linq;

namespace DDD.DomainEvents.InstantPublishing
{
  [TestFixture]
  public class DomainEventsTest
  {
    [Test]
    public void Accept_should_generate_DocumentAcceptedEvent()
    {
      FakeEventPublisher domainEventPublisher = new FakeEventPublisher();
      Document2 d = new Document2();
      DependencyInjector.InjectDependency(d, domainEventPublisher);

      d.Accept();

      var events = domainEventPublisher.UnpublishedEvents;

      Assert.IsTrue(events.Count() == 1);
      Assert.IsTrue(events.First().GetType() == typeof(DocumentAccepted));
    }
  }
}