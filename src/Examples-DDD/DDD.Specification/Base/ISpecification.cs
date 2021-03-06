namespace DDD.Specification.Base
{
  public interface ISpecification<T>
  {
    bool IsSatisfiedBy(T offer);

    ISpecification<T> And(ISpecification<T> other);

    ISpecification<T> Or(ISpecification<T> other);

    ISpecification<T> Not();
  }
}