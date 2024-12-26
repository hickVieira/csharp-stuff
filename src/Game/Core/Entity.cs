namespace Game.Core
{
    public class Entity : I.Referenciable, I.Serializable
    {
        public GUID guid { get; set; }

        public Entity() => this.guid = GUID.None;
        public Entity(GUID guid) => this.guid = guid;
        public virtual string SerializeToJson() => Serde.Serialize.ToJson(this);
    }
}
