using Newtonsoft.Json;

namespace Game;

public struct GUID : I.Serializable
{
    public string SerializeToJson() => Serde.Serialize.ToJson(this);

    public uint id { get; set; } = 0;

    public GUID() => this.id = 0;
    public GUID(uint id) => this.id = id;
    public static GUID None { get => new GUID(0); }
}

public struct Ref<T> : I.Serializable where T : Core.Entity
{
    public string SerializeToJson() => Serde.Serialize.ToJson(this);

    public uint id { get; set; } = 0;
    [JsonIgnore] public T _entity;
    [JsonIgnore] public T entity { get { if (_entity == null) _entity = Game.State.Get<T>(guid); return _entity; } private set => _entity = value; }
    [JsonIgnore] public GUID guid { get => new GUID(this.id); }

    public Ref() => (this.id, this.entity) = (0, default);
    public Ref(uint id) => (this.id, this.entity) = (id, default);
    public Ref(uint id, T obj) => (this.id, this.entity) = (id, obj);
    public static Ref<T> None { get => new Ref<T>(0, default); }
}

public static partial class _
{
    public static Ref<T> Ref<T>(this T obj) where T : Core.Entity => new Ref<T>(obj.guid.id, obj);
    public static string FullName(this object o) => o.GetType().FullName;
}
