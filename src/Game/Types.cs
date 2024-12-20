using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Game;

public class Array<T> : List<T>;
public class Map<TKey, TValue> : Dictionary<TKey, TValue>;

public struct GUID : I.Serializable
{
    public string SerializeToString() => Formatter.Serialize.ToString(this);

    public uint id { get; set; } = 0;

    public GUID() => this.id = 0;
    public GUID(uint id) => this.id = id;
    public static GUID None { get => new GUID(0); }
}

[JsonConverter(typeof(Ref<>.RefConverter))]
public struct Ref<T> : I.Serializable where T : I.Referenciable
{
    class RefConverter : JsonConverter<Ref<T>>
    {
        public override bool CanConvert(System.Type objectType)
        {
            // Ensure the type is a closed generic type
            return objectType.IsGenericType
                   && objectType.GetGenericTypeDefinition() == typeof(Ref<>)
                   && !objectType.ContainsGenericParameters;
        }

        public override void WriteJson(JsonWriter writer, Ref<T> value, JsonSerializer serializer)
        {
            var jsonObject = new JObject
            {
                ["guid"] = JToken.FromObject(value.guid, serializer),
            };
            jsonObject.WriteTo(writer);
        }

        public override Ref<T> ReadJson(JsonReader reader, System.Type objectType, Ref<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            GUID guid = jsonObject["guid"].ToObject<GUID>();
            return new Ref<T>
            {
                id = guid.id,
                entity = (T)Manager.World.Get(guid),
            };
        }
    }

    public string SerializeToString() => Formatter.Serialize.ToString(this, new RefConverter());

    [JsonIgnore] public uint id { get; set; } = 0;
    [JsonIgnore] public T entity { get; set; } = default;

    public Ref() => (this.id, this.entity) = (0, default);
    public Ref(uint id) => (this.id, this.entity) = (id, default);
    public Ref(uint id, T obj) => (this.id, this.entity) = (id, obj);
    public GUID guid { get => new GUID(this.id); }
    public static Ref<T> None { get => new Ref<T>(0, default); }
}

public static partial class _
{
    public static Ref<T> Ref<T>(this T obj) where T : I.Referenciable => new Ref<T>(obj.guid.id, obj);
}
