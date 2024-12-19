using System.Text.Json.Serialization;

namespace Game;

public struct guid : ISerializable
{
    public string Serialize() => Extensions.SerializeToString(this);

    public uint id { get; } = 0;

    public guid() => this.id = 0;
    public guid(uint id) => this.id = id;
    public static guid Default { get => new guid(0); }
}

public struct guid<T> : ISerializable where T : Base.Entity
{
    public string Serialize() => Extensions.SerializeToString(this);

    public uint id { get; } = 0;
    [JsonIgnore] public T entity { get; }

    public guid() => (this.id, this.entity) = (0, null);
    public guid(uint id) => (this.id, this.entity) = (id, null);
    public guid(uint id, T obj) => (this.id, this.entity) = (id, obj);
    public static guid Default { get => new guid(); }
}
