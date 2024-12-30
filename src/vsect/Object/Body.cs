using VSect.Core;
using System.Collections.Generic;

namespace VSect.Object
{
    public class BodyPartData : Core.Object
    {
        public uint Health { get; set; }
        public uint MaxHealth { get; set; }
    }

    public class Body : Core.Object
    {
        public Ref<Character> Character { get; set; }
        public Dictionary<string, BodyPartData> BodyPartData { get; set; }
    }
}