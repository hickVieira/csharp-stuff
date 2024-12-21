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

// [JsonConverter(typeof(RefConverter))]
// [JsonConverter(typeof(RefConverter))]
public class Ref : I.Serializable
{
    public virtual string SerializeToString() => Formatter.Serialize.ToString(this);

    public uint id { get; set; } = 0;
    public object entity { get; set; } = default;

    public Ref() => (this.id, this.entity) = (0, default);
    public Ref(uint id) => (this.id, this.entity) = (id, default);
    public Ref(uint id, object obj) => (this.id, this.entity) = (id, obj);
    public static Ref None { get => new Ref(0, default); }
    public GUID guid { get => new GUID(this.id); }
    public RefT<T> RefT<T>() => new RefT<T>(id, (T)entity);
}

public class RefT<T> : Ref
{
    public override string SerializeToString() => Formatter.Serialize.ToString(this);

    public new T entity { get => (T)base.entity; set => base.entity = value; }

    public RefT() => (this.id, this.entity) = (0, default);
    public RefT(uint id) => (this.id, this.entity) = (id, default);
    public RefT(uint id, T obj) => (this.id, this.entity) = (id, obj);
    public Ref Ref() => new Ref(id, entity);
}

public static partial class _
{
    public static Ref Ref<T>(this T obj) where T : I.Referenciable => new Ref(obj.guid.id, obj);
    public static RefT<T> RefT<T>(this T obj) where T : I.Referenciable => new RefT<T>(obj.guid.id, obj);
}

// class RefConverter : JsonConverter<Ref>
// {
//     public override void WriteJson(JsonWriter writer, Ref value, JsonSerializer serializer)
//     {
//         var jsonObject = new JObject
//         {
//             ["guid"] = JToken.FromObject(value.guid, serializer),
//         };
//         jsonObject.WriteTo(writer);
//     }

//     public override Ref ReadJson(JsonReader reader, System.Type objectType, Ref existingValue, bool hasExistingValue, JsonSerializer serializer)
//     {
//         var jsonObject = JObject.Load(reader);
//         GUID guid = jsonObject["guid"].ToObject<GUID>();
//         return new Ref
//         {
//             id = guid.id,
//             entity = Manager.World.Get(guid),
//         };
//     }
// }