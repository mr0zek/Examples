namespace DDD.Infrastructure.Base.EventSourcing
{
  public class Event
  {
    public Event(int aggregateId, string type, string data, int version)
    {
      AggregateId = aggregateId;
      Type = type;
      Data = data;
      Version = version;
    }

    protected Event()
    { }

    public virtual int Id { get; set; }

    public virtual int AggregateId { get; set; }

    public virtual string Type { get; set; }

    public virtual string Data { get; set; }

    public virtual int Version { get; set; }
  }
}