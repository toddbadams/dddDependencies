namespace ddd.Core.Providers
{
    public interface ISerializationProvider
    {
        string Serialize<T>(T obj);
        T DeserializeSingle<T>(string json);
        T[] DeserializeArray<T>(string json);
    }
}
