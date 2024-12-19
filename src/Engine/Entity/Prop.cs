namespace Game.Entity;

public class Prop : Base.Entity
{
    public class Data : Base.Data
    {
    }
    public new Data data { get; } = new();
}
