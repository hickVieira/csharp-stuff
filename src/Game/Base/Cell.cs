namespace Game.Base;

public class Cell : I.Serializable
{
    public string SerializeToString() => Formatter.Serialize.ToString(this);
    public string SerializeToStringVersioned(uint version) => Formatter.Serialize.ToStringVersioned(version, this);
}