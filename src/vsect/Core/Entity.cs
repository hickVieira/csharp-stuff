using Newtonsoft.Json;

namespace VSect.Core
{
    public abstract class Entity : I.Referenciable, I.Serializable
    {
        [JsonIgnore] public uint guid { get; set; }

        public Entity() => this.guid = 0;
        public Entity(uint guid) => this.guid = guid;
        public virtual string SerializeToJson() => Serde.Serialize.ToJson(this);
    }
}