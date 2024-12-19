namespace Game.Entity;

public class GunAmmo : Base.Entity
{
    public class Data : Base.Data
    {
        public float DamageMultiplier { get; }
        public float AccuracyMultiplier { get; }
        public float RecoilMultiplier { get; }
    }
    public new Data data { get; }
}

public class GunMagazine : Base.Entity
{
    public class Data : Base.Data
    {
        public uint LoadedRounds { get; }
        public uint MaxRounds { get; }
        public guid<GunAmmo> Ammo { get; }
    }
    public new Data data { get; }
}

public class GunMod : Base.Entity
{
    public class Data : Base.Data
    {
        public float DamageMultiplier { get; }
        public float AccuracyMultiplier { get; }
        public float RecoilMultiplier { get; }
        public uint RoundsPerShotMultiplier { get; }
    }
    public new Data data { get; }
}

public class Gun : Base.Entity
{
    public class Data : Base.Data
    {
        public float Damage { get; }
        public float Accuracy { get; }
        public float Recoil { get; }
        public uint RoundsPerShot { get; }
        public guid<GunMagazine> Magazine { get; }
        public guid<GunMod>[] Mods { get; }
        public guid<GunAmmo>[] ChamberedRounds { get; }
    }
    public new Data data { get; } = new();
}
