namespace Game.Entity;

public class Container : Base.Entity
{
    public class Data : Base.Data
    {
        public bool Locked { get; }
        public guid<Base.Entity>[] Items { get; }
    }
    public new Data data { get; } = new();
}
