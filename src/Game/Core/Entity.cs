using Newtonsoft.Json;

namespace Game.Core
{
    public abstract class Entity : I.Referenciable, I.Serializable
    {
        [JsonIgnore] public GUID guid { get; set; }

        public Entity() => this.guid = 0;
        public Entity(GUID guid) => this.guid = guid;
        public virtual string SerializeToJson() => Serde.Serialize.ToJson(this);
    }
}