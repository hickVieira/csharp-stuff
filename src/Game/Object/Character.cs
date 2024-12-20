namespace Game.Object;

public class Character : Base.Object, I.Named, I.Lifeform, I.Physical, I.Interactable
{
    public string Name { get; set; }
    public uint Health { get; set; }
    public uint MaxHealth { get; set; }
    public uint Stamina { get; set; }
    public uint MaxStamina { get; set; }
    public uint Magica { get; set; }
    public uint MaxMagica { get; set; }
    public Ref<Container> Inventory { get; set; }
    public Array<Ref<Base.Object>> Equipped { get; set; }
    public float Mass { get; set; }

    public void Interact() { }
}
