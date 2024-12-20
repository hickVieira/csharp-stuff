using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Game;

public static class Formatter
{
    public class Data<T>
    {
        public T data { get; set; }
        public Data(T data) => this.data = data;
    }

    public class VersionedData<W> : Data<W>
    {
        public uint version { get; set; }
        public VersionedData(uint version, W data) : base(data) => this.version = version;
    }

    public static JObject ParseJson(string jsonString) => JObject.Parse(jsonString);

    public static int ReadVersion(this JObject json)
    {
        if (json.TryGetValue("version", out var version))
            return version.Value<int>();
        else
            return -1;
    }

    public static class Serialize
    {
        public static string ToString<T>(T obj) => JsonConvert.SerializeObject(obj);
        public static byte[] ToBytes<T>(T obj) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));

        public static string ToStringVersioned<T>(uint version, T obj) => JsonConvert.SerializeObject(new VersionedData<T>(version, obj));
        public static byte[] ToBytesVersioned<T>(uint version, T obj) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new VersionedData<T>(version, obj)));
    }

    public static class Deserialize
    {
        public static Data<T> FromString<T>(string str) => new Data<T>(JsonConvert.DeserializeObject<T>(str));
        public static Data<T> FromBytes<T>(byte[] data) => new Data<T>(JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data)));
        public static Data<T> FromJson<T>(JObject json) => new Data<T>(json.ToObject<T>());

        public static VersionedData<T> FromStringVersioned<T>(string str) => JsonConvert.DeserializeObject<VersionedData<T>>(str);
        public static VersionedData<T> FromBytesVersioned<T>(byte[] data) => JsonConvert.DeserializeObject<VersionedData<T>>(Encoding.UTF8.GetString(data));
        public static VersionedData<T> FromJsonVersioned<T>(JObject json) => json.ToObject<VersionedData<T>>();
    }
}