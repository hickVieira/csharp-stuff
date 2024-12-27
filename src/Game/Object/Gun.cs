using Game.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Game.Object
{
    public class GunMod : Item, I.Named
    {
        public class Config : Gun.Config
        {
        }
        public Ref<Config> config { get; set; }

        [JsonIgnore] public string Name { get => config.entity.Name; }
    }

    public class Gun : Item, I.Named
    {
        public class Config : Core.Config
        {
            public string Name { get; set; }
            public float Damage { get; set; }
            public float Accuracy { get; set; }
            public float Recoil { get; set; }
            public float Range { get; set; }
            public uint RateOfFire { get; set; }
            public float ReloadTime { get; set; }
            public float MuzzleVelocity { get; set; }
            public uint MagazineSize { get; set; }
            public uint AmmoPerShot { get; set; }
        }
        public Ref<Config> config { get; set; }

        [JsonIgnore] public string Name { get => config.entity.Name; }
        [JsonIgnore] public float Damage { get => config.entity.Damage; }
        [JsonIgnore] public float Accuracy { get => config.entity.Accuracy; }
        [JsonIgnore] public float Recoil { get => config.entity.Recoil; }
        [JsonIgnore] public float Range { get => config.entity.Range; }
        [JsonIgnore] public uint RateOfFire { get => config.entity.RateOfFire; }
        [JsonIgnore] public float ReloadTime { get => config.entity.ReloadTime; }
        [JsonIgnore] public float MuzzleVelocity { get => config.entity.MuzzleVelocity; }
        [JsonIgnore] public uint MagazineSize { get => config.entity.MagazineSize; }
        [JsonIgnore] public uint AmmoPerShot { get => config.entity.AmmoPerShot; }

        public uint AmmoInMagazine { get; set; }
        public uint ChamberedAmmo { get; set; }
        public Ref<Ammo> Ammo { get; set; }
        public List<Ref<GunMod>> Mods { get; set; }
    }
}