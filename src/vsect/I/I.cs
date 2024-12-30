using VSect.Core;
using System.Collections.Generic;

namespace VSect.I
{
    public interface Referenciable
    {
        public uint guid { get; }
    }

    public interface Serializable
    {
        string SerializeToJson();
    }

    public interface Named
    {
        string Name { get; }
    }

    public interface Physical
    {
        float Mass { get; }
    }

    public interface Mage
    {
        public uint Magica { get; set; }
        public uint MaxMagica { get; }
    }

    public interface Lifeform
    {
        uint Health { get; }
        uint MaxHealth { get; }
        uint Stamina { get; }
        uint MaxStamina { get; }
        void Sleep();
        void Die();
    }

    public interface Damageable
    {
        void TakeDamage();
    }

    public interface Pickable
    {
        void Pickup();
    }

    public interface Stackable
    {
        int Quantity { get; }
        int MaxQuantity { get; }
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
        List<Ref<Object.Item>> Items { get; }
    }

    public interface Equippable
    {
        void Equip();
    }

    public interface Consumable
    {
        void Consume();
    }
}