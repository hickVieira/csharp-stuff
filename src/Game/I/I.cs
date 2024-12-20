namespace Game.I;

public interface Referenciable
{
    public GUID guid { get; set; }
}

public interface Serializable
{
    string SerializeToString();
}

public interface SerializableVersioned
{
    string SerializeToStringVersioned(uint version);
}

public interface Named
{
    string Name { get; set; }
}

public interface Physical
{
    float Mass { get; set; }
}

public interface Lifeform
{
    uint Health { get; set; }
    uint MaxHealth { get; set; }
    uint Stamina { get; set; }
    uint MaxStamina { get; set; }
}

public interface Pickable
{
    void Pickup();
}

public interface Stackable
{
    int Quantity { get; set; }
    int MaxQuantity { get; set; }
}

public interface Fireable
{
    void Fire();
}

public interface Toggleable
{
    void Toggle();
}

public interface Interactable
{
    void Interact();
}

public interface Storage
{
    Array<Base.Object> Objects { get; set; }
}

public interface Equippable
{
    void Equip();
}

public interface Consumable
{
    void Consume();
}