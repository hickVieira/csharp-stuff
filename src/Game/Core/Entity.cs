namespace Game.Core
{
    public class Entity : I.Referenciable, I.Serializable, I.SerializableVersioned
    {
        public GUID guid { get; set; }

        public Entity() => this.guid = GUID.None;
        public Entity(GUID guid) => this.guid = guid;
        public virtual string SerializeToString() => Serde.Serialize.ToString(this);
        public virtual string SerializeToStringVersioned(uint version) => Serde.Serialize.ToStringVersioned(version, this);
    }
}
