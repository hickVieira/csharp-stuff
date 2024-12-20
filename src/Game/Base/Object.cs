namespace Game.Base;

public class Object : I.Serializable
{
    public GUID guid { get; set; }

    public Object() => this.guid = GUID.None;
    public Object(GUID guid) => this.guid = guid;
    public string SerializeToString() => Formatter.Serialize.ToString(this);
    public string SerializeToStringVersioned(uint version) => Formatter.Serialize.ToStringVersioned(version, this);
}

public static partial class _
{
    public static Ref<T> Ref<T>(this T obj) where T : Object => new Ref<T>(obj.guid.id, obj);
}