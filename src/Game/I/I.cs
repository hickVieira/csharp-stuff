namespace Game.I;

interface Serializable
{
    string SerializeToString();
    string SerializeToStringVersioned(uint version);
}

interface World
{
    T RegisterObject<T>(T obj) where T : Base.Object;
    // async Task<T> DeleteObject<T>(guid guid) where T : Base.Object => await Task.FromResult<T>(default);
    // async Task<T> LoadObject<T>(guid guid) where T : Base.Object => await Task.FromResult<T>(default);
    // async Task<T> UnloadObject<T>(guid guid) where T : Base.Object => await Task.FromResult<T>(default);
    void DeleteObject<T>(GUID guid) where T : Base.Object;
    T LoadObject<T>(GUID guid) where T : Base.Object;
    void UnloadObject<T>(GUID guid) where T : Base.Object;
}

interface Named
{
    string Name { get; set; }
}

interface Physical
{
    float Mass { get; set; }
}

interface Lifeform
{
    uint Health { get; set; }
    uint MaxHealth { get; set; }
    uint Stamina { get; set; }
    uint MaxStamina { get; set; }
}

interface Pickable
{
    void Pickup();
}

interface Stackable
{
    int Quantity { get; set; }
    int MaxQuantity { get; set; }
}

interface Fireable
{
    void Fire();
}

interface Toggleable
{
    void Toggle();
}

interface Interactable
{
    void Interact();
}

interface Storage
{
    Array<Base.Object> Objects { get; set; }
}

interface Equippable
{
    void Equip();
}

interface Consumable
{
    void Consume();
}