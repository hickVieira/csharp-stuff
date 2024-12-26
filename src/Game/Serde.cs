using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Game;
public static class Serde
{
    public class Data<T>
    {
        public string type { get; set; }
        public T data { get; set; }
        public Data(T data) => (this.type, this.data) = (data.GetType().FullName, data);
    }

    public class VersionedData<W> : Data<W>
    {
        public uint version { get; set; }
        public VersionedData(uint version, W data) : base(data) => this.version = version;
    }

    static readonly Dictionary<string, Type> TypeMap =
            Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(Core.Entity).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .GroupBy(t => (t.FullName, t))
            .ToDictionary(t => t.Key.Item1, t => t.Key.Item2);

    public static JObject ParseJson(string json) => JObject.Parse(json);
    public static uint version(this JObject json) => json["version"].Value<uint>();
    public static string type(this JObject json) => json["type"].Value<string>();

    public static class Serialize
    {
        public static string ToString<T>(T obj) => JsonConvert.SerializeObject(new Data<T>(obj), Formatting.Indented);
        public static byte[] ToBytes<T>(T obj) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Data<T>(obj)));
        public static void ToFile<T>(T obj) where T : I.Referenciable => System.IO.File.WriteAllText($"{obj.guid.id}.json", JsonConvert.SerializeObject(new Data<T>(obj), Formatting.Indented));

        public static string ToStringVersioned<T>(uint version, T obj) => JsonConvert.SerializeObject(new VersionedData<T>(version, obj));
        public static byte[] ToBytesVersioned<T>(uint version, T obj) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new VersionedData<T>(version, obj)));
        public static void ToFileVersioned<T>(uint version, T obj) where T : I.Referenciable => System.IO.File.WriteAllText($"{obj.guid.id}.json", JsonConvert.SerializeObject(new VersionedData<T>(version, obj)));
    }

    public static class Deserialize
    {
        public static Data<T> FromString<T>(string str) => JsonConvert.DeserializeObject<Data<T>>(str);
        public static Data<T> FromBytes<T>(byte[] data) => JsonConvert.DeserializeObject<Data<T>>(Encoding.UTF8.GetString(data));
        public static Data<T> FromJson<T>(JObject json) => json.ToObject<Data<T>>();
        public static Data<T> FromJson<T>(string json) => JsonConvert.DeserializeObject<Data<T>>(json);
        public static Core.Entity FromJson(JObject json) => (Core.Entity)json["data"].ToObject(TypeMap[json["type"].Value<string>()]);

        public static VersionedData<T> FromStringVersioned<T>(string str) => JsonConvert.DeserializeObject<VersionedData<T>>(str);
        public static VersionedData<T> FromBytesVersioned<T>(byte[] data) => JsonConvert.DeserializeObject<VersionedData<T>>(Encoding.UTF8.GetString(data));
        public static VersionedData<T> FromJsonVersioned<T>(JObject json) => json.ToObject<VersionedData<T>>();
        public static VersionedData<T> FromJsonVersioned<T>(string json) => JsonConvert.DeserializeObject<VersionedData<T>>(json);
    }
}