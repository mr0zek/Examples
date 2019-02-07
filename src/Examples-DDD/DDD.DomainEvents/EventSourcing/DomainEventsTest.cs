using DDD.Base.Domain;
using DDD.DomainEvents.DelayedPublishing;
using DDD.Infrastructure.Base.EventSourcing;
using DDD.Policy.ByDepndencyInjector;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using System;
using System.Linq;

namespace DDD.DomainEvents.EventSourcing
{
  [TestFixture]
  public class DomainEventsTest
  {
    private IDocumentFactory _documentFoctory = new DocumentFactory();
    private IGenericEventRepository<Document3> _documentRepository;

    protected ISessionFactory _sessionFactory;

    [TestFixtureSetUp]
    public void FixtureSetup()
    {
      AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

      Configuration _configuration = new Configuration();
      _configuration.DataBaseIntegration(f => f.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote);
      var mapper = new ModelMapper();
      var allEntities = typeof(EventMap).Assembly.GetTypes().ToList();

      var mappings = typeof(EventMap).Assembly.GetTypes().Where(t => IsSubclassOfRawGeneric(typeof(ClassMapping<>), t));
      mapper.AddMappings(mappings);
      var mapping = mapper.CompileMappingFor(allEntities);
      _configuration.AddDeserializedMapping(mapping, "NHSchema");

      _configuration.Configure();

      new SchemaExport(_configuration).Execute(true, true, false);
      _sessionFactory = _configuration.BuildSessionFactory();
    }

    private static bool IsSubclassOfRawGeneric(System.Type generic, System.Type toCheck)
    {
      while (toCheck != null && toCheck != typeof(object))
      {
        var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
        if (generic == cur)
        {
          return true;
        }
        toCheck = toCheck.BaseType;
      }
      return false;
    }

    [Test]
    public void Accept_should_generate_DocumentAcceptedEvent()
    {
      Document3 d = new Document3(12);
      d.Accept();

      var events = (d as IHaveEvents).GetEvents();

      Assert.IsTrue(events.Count() == 2);
      Assert.IsTrue(events.First().GetType() == typeof(DocumentCreated));
      Assert.IsTrue(events.ToList()[1].GetType() == typeof(DocumentAccepted));
    }

    [Test]
    public void Service_full_test()
    {
      using (ISession session = _sessionFactory.OpenSession())
      {
        _documentRepository = new GenericEventRepository<Document3>(session, new EventSerializer());

        Document3 document3 = _documentFoctory.Create(12);
        document3.Accept();
        _documentRepository.Save(document3);

        Document3 doc = _documentRepository.Load(document3.Id);
        Assert.IsNotNull(doc);
      }
    }
  }
}