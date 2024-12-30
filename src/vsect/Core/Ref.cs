using VSect.Core;
using Newtonsoft.Json;

namespace VSect.Core
{
    public struct Ref<T> : I.Serializable where T : Entity
    {
        public string SerializeToJson() => Serde.Serialize.ToJson(this);

        public uint guid { get; set; } = 0;
        [JsonIgnore] public T _entity;
        [JsonIgnore] public T entity { get { if (_entity == null) _entity = State.Get<T>(guid); return _entity; } private set => _entity = value; }

        public Ref() => (this.guid, this.entity) = (0, default);
        public Ref(uint id) => (this.guid, this.entity) = (id, default);
        public Ref(uint id, T obj) => (this.guid, this.entity) = (id, obj);
        public static Ref<T> None { get => new Ref<T>(0, default); }
    }
}

public static partial class _
{
    public static Ref<T> Ref<T>(this T obj) where T : Entity => new Ref<T>(obj.guid, obj);
}