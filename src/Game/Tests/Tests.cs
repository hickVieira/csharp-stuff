/*
- NUnit tests
- Modules folder (base, dlc1, dlc2, mod1, mod2, ...)
- Modules manifest files
- Cells

loadorder.txt (plugin load order) (maybe could make ops like add/mult)
/base
    player.json
    map.json
    ...
/dlc1
    santa.json
    ...
/mod1
    pistol.json
    ...

init
    load_modules
        sort_modules_by_loadorder
        create_manifest
    load_gamesettings
        load_graphics
        load_bindings
    load_mainmenu
        load_gamestate
        set_gamesettings
    loop
        create_objects_from_gamestate
        save_objects_to_gamestate
*/

using Game.Object;

namespace Game.Tests
{
    public static class _
    {
        public static void Run()
        {
            CreateEntities();
            // State.Load();
            State.Save();

            var character = State.Get<Character>(484509646);
            System.Console.WriteLine("\ncharacter.SerializeToJson()\n" + character.SerializeToJson());
        }

        public static void CreateEntities()
        {
            var gunConfig = State.RegisterEntity(new Gun.Config
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

            var ammoConfig = State.RegisterEntity(new Ammo.Config
            {
                Name = "9mm",
                ProjectilesCount = 1,
            });

            var ammo = State.RegisterEntity(new Ammo
            {
                config = ammoConfig.Ref()
            });

            var gun = State.RegisterEntity(new Gun
            {
                config = gunConfig.Ref(),
                AmmoInMagazine = 10,
                ChamberedAmmo = 1,
                Ammo = ammo.Ref(),
                Mods = new(),
            });

            var characterConfig = State.RegisterEntity(new Character.Config
            {
                Name = "Max",
                MaxHealth = 100,
                MaxStamina = 100,
                MaxMagica = 100,
                Mass = 85 / 9.81f,
            });

            var characterContainer = State.RegisterEntity(new Container
            {
                Items = new() { gun.Ref<Item>() },
            });

            var body = State.RegisterEntity(new Body
            {
                BodyPartData = new()
                {
                    {"Head", new BodyPartData { Health=100, MaxHealth=100 }},
                    {"Torso", new BodyPartData { Health=100, MaxHealth=100 }},
                    {"Left Arm", new BodyPartData { Health=100, MaxHealth=100 }},
                    {"Right Arm", new BodyPartData { Health=100, MaxHealth=100 }},
                    {"Left Leg", new BodyPartData { Health=100, MaxHealth=100 }},
                    {"Right Leg", new BodyPartData { Health=100, MaxHealth=100 }},
                },
            });

            var character = State.RegisterEntity(new Character
            {
                config = characterConfig.Ref(),
                Health = 100,
                Stamina = 100,
                Magica = 100,
                Body = body.Ref(),
                Inventory = characterContainer.Ref(),
                Equipped = new(),
            });
            
            System.Console.WriteLine("\ngun.SerializeToJson()\n" + gun.SerializeToJson());
            System.Console.WriteLine("\nSerde.Deserialize.FromJson<Gun>(gun.SerializeToJson())\n" + Serde.Deserialize.FromJson<Gun>(gun.SerializeToJson()).data.SerializeToJson());

            System.Console.WriteLine("\ncharacter.SerializeToJson()\n" + character.SerializeToJson());
            System.Console.WriteLine("\nSerde.Deserialize.FromJson<Character>(character.SerializeToJson())\n" + Serde.Deserialize.FromJson<Character>(character.SerializeToJson()).data.SerializeToJson());

            System.Console.WriteLine("\ncharacterContainer.SerializeToJson()\n" + characterContainer.SerializeToJson());
            System.Console.WriteLine("\nSerde.Deserialize.FromJson<Container>(characterContainer.SerializeToJson())\n" + Serde.Deserialize.FromJson<Container>(characterContainer.SerializeToJson()).data.SerializeToJson());

            System.Console.WriteLine("\nbody.SerializeToJson()\n" + body.SerializeToJson());
            System.Console.WriteLine("\nSerde.Deserialize.FromJson<Body>(body.SerializeToJson())\n" + Serde.Deserialize.FromJson<Body>(body.SerializeToJson()).data.SerializeToJson());
        }
    }
}