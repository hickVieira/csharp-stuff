namespace Game.Object;

public class Character : Core.Object, I.Named, I.Lifeform, I.Damageable, I.Mage, I.Physical, I.Interactable
{
    public class Config : Core.Config
    {
        public string Name { get; set; }
        public uint Health { get; set; }
        public uint MaxHealth { get; set; }
        public uint Stamina { get; set; }
        public uint MaxStamina { get; set; }
        public uint Magica { get; set; }
        public uint MaxMagica { get; set; }
        public float Mass { get; set; }
    }
    public Ref<Config> config;

    public string Name { get => config.entity.Name; }
    public uint MaxHealth { get => config.entity.MaxHealth; }
    public uint MaxStamina { get => config.entity.MaxStamina; }
    public uint MaxMagica { get => config.entity.MaxMagica; }
    public float Mass { get => config.entity.Mass; }

    public uint Health { get; set; }
    public uint Stamina { get; set; }
    public uint Magica { get; set; }
    public Ref<Container> Inventory { get; set; }
    public Array<Ref<Core.Object>> Equipped { get; set; }

    public void Interact() { }

    public void TakeDamage() { }

    public void Sleep() { }

    public void Die() { }
}
