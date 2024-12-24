using System.Collections.Generic;
using Newtonsoft.Json;

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

public struct Ref<T> : I.Serializable
{
    public string SerializeToString() => Formatter.Serialize.ToString(this);

    public uint id { get; set; } = 0;
    [JsonIgnore] public T _entity;
    [JsonIgnore] public T entity { get { if (_entity == null) _entity = (T)Game.State.Data.Get(guid); return _entity; } private set => _entity = value; }
    [JsonIgnore] public GUID guid { get => new GUID(this.id); }

    public Ref() => (this.id, this.entity) = (0, default);
    public Ref(uint id) => (this.id, this.entity) = (id, default);
    public Ref(uint id, T obj) => (this.id, this.entity) = (id, obj);
    public static Ref<T> None { get => new Ref<T>(0, default); }
}

public static partial class _
{
    public static Ref<T> Ref<T>(this T obj) where T : I.Referenciable => new Ref<T>(obj.guid.id, obj);
}
