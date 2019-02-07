namespace DDD.Base.Domain
{
  public abstract class Entity
  {
    public int Id { get; protected set; }

    protected Entity()
    {
    }
  }
}