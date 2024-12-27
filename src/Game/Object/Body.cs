using System.Collections.Generic;

namespace Game.Object
{
    public class BodyPartData : Core.Object
    {
        public uint Health { get; set; }
        public uint MaxHealth { get; set; }
    }

    public class Body : Core.Object
    {
        public Dictionary<string, BodyPartData> BodyPartData { get; set; }
    }
}