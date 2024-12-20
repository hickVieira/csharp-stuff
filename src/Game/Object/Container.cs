
namespace Game.Object;

public class Container : Base.Object, I.Storage
{
    public bool Locked { get; set; }
    public Array<Base.Object> Objects { get; set; }
}
