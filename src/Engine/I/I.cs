namespace Game.I;

public interface Physical
{
    public float Mass { get; }
}

public interface Lifeform
{
    public uint Health { get; }
    public uint MaxHealth { get; }
    public uint Stamina { get; }
    public uint MaxStamina { get; }
}

public interface Pickable
{
    public void Pickup();
}

public interface Stackable
{
    public int Quantity { get; }
    public int MaxQuantity { get; }
}

public interface Fireable
{
    public void Fire();
}

public interface Toggleable
{
    public void Toggle();
}

public interface Interactable
{
    public void Interact();
}