using System.Collections.Generic;
using Newtonsoft.Json;

namespace Game;

public class Array<T> : List<T>;
public class Map<TKey, TValue> : Dictionary<TKey, TValue>;

public struct GUID : I.Serializable
{
    public string SerializeToString() => Formatter.Serialize.ToString(this);
    public string SerializeToStringVersioned(uint version) => Formatter.Serialize.ToStringVersioned(version, this);

    public uint id { get; set; } = 0;

    public GUID() => this.id = 0;
    public GUID(uint id) => this.id = id;
    public static GUID None { get => new GUID(0); }
}

public struct Ref<T> : I.Serializable where T : Base.Object
{
    public string SerializeToString() => Formatter.Serialize.ToString(this);
    public string SerializeToStringVersioned(uint version) => Formatter.Serialize.ToStringVersioned(version, this);

    public uint id { get; set; } = 0;
    [JsonIgnore] public T @object { get; set; }

    public Ref() => (this.id, this.@object) = (0, null);
    public Ref(uint id) => (this.id, this.@object) = (id, null);
    public Ref(uint id, T obj) => (this.id, this.@object) = (id, obj);
    public GUID guid { get => new GUID(this.id); }
    public static Ref<T> None { get => new Ref<T>(0, default); }
}
