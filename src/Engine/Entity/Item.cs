namespace Game.Entity;

public class Item : Base.Entity
{
    public class Data : Base.Data
    {
    }
    public new Data data { get; } = new();
}
