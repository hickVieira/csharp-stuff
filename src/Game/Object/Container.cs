using System.Collections.Generic;

namespace Game.Object;

public class Container : Core.Object, I.Storage
{
    public bool Locked { get; set; }
    public List<Core.Object> Objects { get; set; }
}
