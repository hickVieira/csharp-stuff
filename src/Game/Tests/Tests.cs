using Game.Object;

namespace Game.Tests;

public static class _
{
    public static void Run()
    {
        Character character = new();
        character.guid = new GUID(10);
        character.Name = "Max";
        character.Mass = 65f / 9.81f;

        var raw = character.SerializeToString();
        var versioned = character.SerializeToStringVersioned(1);
        var json = Formatter.ParseJson(raw);

        System.Console.WriteLine(raw);
        System.Console.WriteLine(versioned);
        System.Console.WriteLine("guid is " + character.guid.id);
        System.Console.WriteLine("guid is " + Formatter.Deserialize.FromString<Character>(raw).data.guid.id);
        System.Console.WriteLine("version is " + Formatter.ParseJson(versioned).ReadVersion());

        var ent1 = Formatter.Deserialize.FromString<Character>(raw);
        System.Console.WriteLine("names is " + ent1.data.Name);
        var ent2 = Formatter.Deserialize.FromStringVersioned<Character>(versioned);
        System.Console.WriteLine("names is " + ent2.data.Name);
        var ent3 = Formatter.Deserialize.FromJson<Base.Object>(json);
        System.Console.WriteLine("guid is " + ent3.data.guid.id);

        var gunConfig = Manager.World.RegisterEntity(new Gun.Config
        {
            Damage = 10,
            Accuracy = 10,
            Recoil = 10,
            RateOfFire = 10,
            ReloadTime = 3.5f,
            MuzzleVelocity = 500,
            MagazineSize = 10,
            AmmoPerShot = 10,
        });

        var gunAmmo = Manager.World.RegisterEntity(new GunAmmo
        {
            ProjectilesCount = 1,
        });

        var gun = Manager.World.RegisterEntity(new Gun
        {
            config = gunConfig.Ref(),
            LoadedAmmo = 10,
            ChamberedAmmo = 10,
            Ammo = gunAmmo.Ref(),
        });

        var serialGun = gun.SerializeToString();
        var deserialGun = Formatter.Deserialize.FromString<Gun>(serialGun);

        System.Console.WriteLine(serialGun);
        System.Console.WriteLine(gun.Ammo.SerializeToString());
        System.Console.WriteLine(deserialGun.data.Ammo.SerializeToString());
        System.Console.WriteLine(deserialGun.data.Ammo.entity.SerializeToString());

        // System.Console.WriteLine(gun.SerializeToString());
        // gun.LoadedAmmo = 20;
        // System.Console.WriteLine(Manager.World.Get<Gun.Config>(gun.config.guid).SerializeToString());
        // System.Console.WriteLine(Manager.World.Get<GunAmmo>(gun.Ammo.guid).SerializeToString());
    }
}