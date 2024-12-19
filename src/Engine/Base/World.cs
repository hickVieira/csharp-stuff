using Game.I;

namespace Game.Base;

public class World : ISerializable
{
    public uint version => 0;
    public string Serialize() => this.SerializeToString();

    public Entity[] entities { get; }
}