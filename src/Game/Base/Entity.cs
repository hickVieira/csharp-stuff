namespace Game.Base
{
    public class Entity : I.Referenciable, I.Serializable, I.SerializableVersioned
    {
        public GUID guid { get; set; }

        public Entity() => this.guid = GUID.None;
        public Entity(GUID guid) => this.guid = guid;
        public string SerializeToString() => Formatter.Serialize.ToString(this);
        public string SerializeToStringVersioned(uint version) => Formatter.Serialize.ToStringVersioned(version, this);
    }
}
