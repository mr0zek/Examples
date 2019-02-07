using CQRS.Application.Base;
using CQRS.Application.Contract;
using CQRS.Application.Handlers;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;
using CQRS.Finders;
using CQRS.Infrastructure;
using CQRS.RestApi.Infrastructure;
using StructureMap;
using StructureMap.Pipeline;

namespace CQRS.RestApi
{
  internal class StructuremapRegistry : Registry
  {
    public StructuremapRegistry()
    {
      For<IEventStore>().Use<EventStore>();
      For<IEventPublisher>().Use<EventPublisher>().Singleton();
      For<ICommandSender>().Use<CommandSender>();
      ForConcreteType<InMemoryFinder>().Configure.Singleton();
      For<IInventoryItemDetailFinder>().Use(c => c.GetInstance<InMemoryFinder>());
      For<IInventoryItemListFinder>().Use(c => c.GetInstance<InMemoryFinder>());
      For<IDependencyResolver>().Use<StructureMapDependencyResolverAdapter>();
      For<IHandler<ICheckInItemsToInventoryCommand>>().Use<CheckInItemsToInventoryHandler>();
      For<IHandler<ICreateInventoryItemCommand>>().Use<CreateInventoryItemHandler>();
      For<IHandler<IDeactivateInventoryItemCommand>>().Use<DeactivateInventoryItemHandler>();
      For<IHandler<IRemoveItemsFromInventoryCommand>>().Use<RemoveItemsFromInventoryHandler>();
      For<IHandler<IRenameInventoryItemCommand>>().Use<RenameInventoryItemHandler>();
      For<IRepository<InventoryItem>>().Use<Repository<InventoryItem>>();
    }
  }
}