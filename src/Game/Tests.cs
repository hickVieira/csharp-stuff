using Game.Base;
using Game.Object;

namespace Game;

public static class Tests
{
    public static void Run()
    {
        // Game
        {
            Game.Object.Character character = new();
            character.guid = new GUID(10);
            character.Name = "Max";
            character.Mass = 65f / 9.81f;

            var raw = character.SerializeToString();
            var versioned = character.SerializeToStringVersioned(1);
            var json = Formatter.ParseJson(raw);

            System.Console.WriteLine(raw);
            System.Console.WriteLine(versioned);
            System.Console.WriteLine("guid is " + character.guid.id);
            System.Console.WriteLine("guid is " + Formatter.Deserialize.FromString<Game.Object.Character>(raw).data.guid.id);
            System.Console.WriteLine("version is " + Formatter.ParseJson(versioned).ReadVersion());

            var ent1 = Formatter.Deserialize.FromString<Game.Object.Character>(raw);
            System.Console.WriteLine("names is " + ent1.data.Name);
            var ent2 = Formatter.Deserialize.FromStringVersioned<Game.Object.Character>(versioned);
            System.Console.WriteLine("names is " + ent2.data.Name);
            var ent3 = Formatter.Deserialize.FromJson<Game.Base.Object>(json);
            System.Console.WriteLine("guid is " + ent3.data.guid.id);

            var world = new World();

            var gunAmmo = world.RegisterObject(new GunAmmo
            {
                ProjectilesCount = 1,
            });

            var gun = world.RegisterObject(new Gun
            {
                Damage = 10,
                Accuracy = 10,
                Recoil = 10,
                RateOfFire = 10,
                ReloadTime = 3.5f,
                AmmoSpeed = 500,
                MagazineSize = 10,
                AmmoPerShot = 10,
                LoadedAmmo = 10,
                ChamberedAmmo = 10,
                Ammo = gunAmmo.Ref(),
            });

            System.Console.WriteLine(gun.SerializeToString());
            gun.Damage = 20;
            System.Console.WriteLine(world.LoadObject<Gun>(gun.guid).SerializeToString());
            System.Console.WriteLine(world.LoadObject<GunAmmo>(gun.Ammo.guid).SerializeToString());
        }
    }
}