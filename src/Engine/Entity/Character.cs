namespace Game.Entity;

public class Character : Base.Entity, I.Lifeform, I.Physical, I.Interactable
{
    public uint Health { get; }
    public uint MaxHealth { get; }
    public uint Stamina { get; }
    public uint MaxStamina { get; }
    public uint Magica { get; }
    public uint MaxMagica { get; }
    public guid<Entity.Container>[] Inventory { get; }
    public guid<Base.Entity>[] Equipped { get; }

    public float Mass { get; }

    public void Interact() { }
}
