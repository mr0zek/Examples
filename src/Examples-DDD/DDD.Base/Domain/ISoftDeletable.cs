namespace DDD.Base.Domain
{
  public interface ISoftDeletable
  {
    bool IsRemoved();

    void MarkAsRemoved();
  }
}