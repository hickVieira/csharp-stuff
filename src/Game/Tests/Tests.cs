using Game.Object;

namespace Game.Tests;

public static class _
{
    public static void Run()
    {
        // CreateEntities();
        Game.State.Load();
        // Game.State.Save();
    }

    public static void CreateEntities()
    {
        var gunConfig = Game.State.RegisterEntity(new Gun.Config
        {
            Name = "Glock",
            Damage = 10,
            Accuracy = 10,
            Recoil = 10,
            RateOfFire = 10,
            ReloadTime = 3.5f,
            MuzzleVelocity = 500,
            MagazineSize = 10,
            AmmoPerShot = 10,
        });

        var ammoConfig = Game.State.RegisterEntity(new Ammo.Config
        {
            Name = "9mm",
            ProjectilesCount = 1,
        });

        var ammo = Game.State.RegisterEntity(new Ammo
        {
            config = ammoConfig.Ref()
        });

        var gun = Game.State.RegisterEntity(new Gun
        {
            config = gunConfig.Ref(),
            AmmoInMagazine = 10,
            ChamberedAmmo = 1,
            Ammo = ammo.Ref(),
        });

        var serialGun = gun.SerializeToString();
        var deserialGun = Serde.Deserialize.FromString<Gun>(serialGun);

        System.Console.WriteLine("\nserialGun\n" + serialGun);
        System.Console.WriteLine("\ngun.Ammo.SerializeToString()\n" + gun.Ammo.SerializeToString());
        System.Console.WriteLine("\ndeserialGun\n" + deserialGun);
        System.Console.WriteLine("\ndeserialGun.data.SerializeToString\n" + deserialGun.data.SerializeToString());
        System.Console.WriteLine("\ndeserialGun.data.Ammo\n" + deserialGun.data.Ammo.SerializeToString());
        System.Console.WriteLine("\ndeserialGun.data.Ammo.entity\n" + deserialGun.data.Ammo.entity.SerializeToString());
    }
}