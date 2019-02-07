using CQRS.Application.Base;
using StructureMap;

namespace CQRS.RestApi.Infrastructure
{
    class StructureMapDependencyResolverAdapter : IDependencyResolver
    {
      private IContainer _container;

      public StructureMapDependencyResolverAdapter(IContainer container)
      {
        _container = container;
      }

      public T Resolve<T>()
      {
        return _container.GetInstance<T>();        
      }
    }
}
