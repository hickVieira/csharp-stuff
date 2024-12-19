namespace Game.Base;

public abstract class Data : ISerializable
{
    public virtual string Serialize() => Extensions.SerializeToString(this);
}

// public abstract class Entity : ISerializableVersioned
// {
//     public uint version => 0;
//     public virtual object Serialize() => this.SerializeToString();

//     public guid guid { get; }
//     public virtual Data data { get; }
// }

public class SerializedEntity : ISerializable
{
    
}

public class Entity : ISerializable
{
    public guid guid { get; }

    public Entity() => this.guid = guid.Default;
    public Entity(guid guid) => this.guid = guid;
    public virtual string Serialize() => this.SerializeToString();
    public virtual string SerializeVersioned(uint version) => new EntityVersioned(version, this).SerializeToString();
}

public class EntityVersioned
{
    public uint version { get; }
    public Entity data { get; }
    public EntityVersioned(uint version, Entity data) => (this.version, this.data) = (version, data);
}