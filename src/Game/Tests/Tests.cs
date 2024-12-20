using Game.Object;
using Newtonsoft.Json;

namespace Game.Tests;

public static class _
{
    public static void Run()
    {
        var characterConfig = Manager.World.RegisterEntity(new Character.Config
        {
            Name = "Max",
            Health = 100,
            MaxHealth = 100,
            Stamina = 100,
            MaxStamina = 100,
            Magica = 100,
            MaxMagica = 100,
            Mass = 80f / 9.81f,
        });

        var character = Manager.World.RegisterEntity(new Character
        {
            config = characterConfig.Ref(),
            Health = 50,
            Stamina = 25,
            Magica = 75,
        });

        // var raw = character.SerializeToString();
        // var versioned = character.SerializeToStringVersioned(1);
        // var json = Formatter.ParseJson(raw);

        // System.Console.WriteLine(raw);
        // System.Console.WriteLine(versioned);
        // System.Console.WriteLine("guid is " + character.guid.id);
        // System.Console.WriteLine("guid is " + Formatter.Deserialize.FromString<Character>(raw).data.guid.id);
        // System.Console.WriteLine("version is " + Formatter.ParseJson(versioned).ReadVersion());

        // var ent1 = Formatter.Deserialize.FromString<Character>(raw);
        // System.Console.WriteLine("names is " + ent1.data.Name);
        // var ent2 = Formatter.Deserialize.FromStringVersioned<Character>(versioned);
        // System.Console.WriteLine("names is " + ent2.data.Name);
        // var ent3 = Formatter.Deserialize.FromJson<Base.Object>(json);
        // System.Console.WriteLine("guid is " + ent3.data.guid.id);

        var gunConfig = Manager.World.RegisterEntity(new Gun.Config
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

        var ammoConfig = Manager.World.RegisterEntity(new Ammo.Config
        {
            Name = "9mm",
            ProjectilesCount = 1,
        });

        var ammo = Manager.World.RegisterEntity(new Ammo
        {
            config = ammoConfig.Ref()
        });

        var gun = Manager.World.RegisterEntity(new Gun
        {
            config = gunConfig.Ref(),
            AmmoInMagazine = 10,
            ChamberedAmmo = 1,
            Ammo = ammo.Ref(),
        });

        var serialObj = JsonConvert.SerializeObject(new Ref<Base.Object>());

        System.Console.WriteLine("\nserialObj()\n" + serialObj);

        return;

        var serialGun = gun.SerializeToString();
        var deserialGun = Formatter.Deserialize.FromString<Gun>(serialGun);

        System.Console.WriteLine("\ngun.SerializeToString()\n" + serialGun);
        // System.Console.WriteLine("\ngun.Ammo.SerializeToString()\n" + gun.Ammo.SerializeToString());
        // System.Console.WriteLine("\n" + deserialGun.data.Ammo.SerializeToString());
        // System.Console.WriteLine("\n" + deserialGun.data.Ammo.entity.SerializeToString());
    }
}