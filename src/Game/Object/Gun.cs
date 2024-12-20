namespace Game.Object;

public class GunAmmo : Base.Config
{
    public uint ProjectilesCount { get; set; }
}

public class GunPart : Base.Config
{
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

public class GunMod : GunPart
{
}

public class Gun : Base.Object, I.Named
{
    public class Config : GunPart
    {
        public string Name { get; set; }
    }
    public Ref<Config> config { get; set; }

    public string Name { get => config.entity.Name; }

    public uint AmmoInMagazine { get; set; }
    public uint ChamberedAmmo { get; set; }
    public Ref<GunAmmo> Ammo { get; set; }
    public Ref<GunMod>[] Mods { get; set; }
}
