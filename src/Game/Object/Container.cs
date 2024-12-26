
namespace Game.Object;

public class Container : Core.Object, I.Storage
{
    public bool Locked { get; set; }
    public Array<Core.Object> Objects { get; set; }
}
