using DDD.Base.Domain;
using NUnit.Framework;
using System.Linq;

namespace DDD.DomainEvents.DelayedPublishing
{
  [TestFixture]
  public class DomainEventsTest
  {
    [Test]
    public void Accept_should_generate_DocumentAcceptedEvent()
    {
      Document d = new Document();
      d.Accept();

      var events = (d as IUnpublishedEventsAccesor).GetUnpublishedEvents();

      Assert.IsTrue(events.Count() == 1);
      Assert.IsTrue(events.First().GetType() == typeof(DocumentAccepted));
    }
  }
}