namespace DDD.Sagas.Base
{
  public interface ISerializer
  {
    T Deserialize<T>(string serializedData) where T : class;

    string Serialize(object sagaData);
  }
}