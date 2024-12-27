namespace Game.Core
{
    public struct GUID : I.Serializable
    {
        public string SerializeToJson() => Serde.Serialize.ToJson(this);

        public uint id { get; set; } = 0;

        public GUID() => this.id = 0;
        public GUID(uint id) => this.id = id;
        public static implicit operator GUID(uint id) => new GUID(id);
    }
}