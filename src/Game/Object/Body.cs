using System.Collections.Generic;

namespace Game.Object
{
    public class BodyPart : Core.Object
    {
        public string Name { get; set; }
        public uint Health { get; set; }
    }

    public class Body : Core.Object
    {
        public Dictionary<string, BodyPart> BodyParts { get; set; }
    }
}