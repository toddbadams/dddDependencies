using System.Collections.Generic;
using ddd.Core.Providers;
using Newtonsoft.Json;

namespace ddd.NewtonSoftSerializer
{
    public class NewtonSoftSerializationProvider : ISerializationProvider
    {
        public string Serialize<T>(T obj)
        {
            var result = JsonConvert.SerializeObject(obj);
            return result;
        }

        public T DeserializeSingle<T>(string json)
        {
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public T[] DeserializeArray<T>(string json)
        {
            var result = JsonConvert.DeserializeObject<List<T>>(json).ToArray();
            return result;
        }
    }
}
