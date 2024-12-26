using System;
using Game.Core;
using Game.Object;

namespace Game
{
    public static class State
    {
        public static Map<uint, Core.Entity> Entities { get; private set; } = new();

        public static void Load()
        {
            Entities.Clear();
            foreach (var file in System.IO.Directory.EnumerateFiles("./Content"))
            {
                var json = Serde.ParseJson(System.IO.File.ReadAllText(file));
                // var type = json.type();
                // var version = json.version();

                // Entity ent = default;
                // ent = type switch
                // {
                //     "Character" => Serde.Deserialize.FromJson<Character>(json).data,
                //     _ => Serde.Deserialize.FromJson<Entity>(json).data,
                // };

                Console.WriteLine("json = " + json);
                var ent = Serde.Deserialize.FromJson(json);
                Console.WriteLine(ent.SerializeToString());

                // Entities.Add(ent.guid.id, ent);
            }
        }

        public static void Save()
        {
            foreach (var ent in Entities.Values)
                System.IO.File.WriteAllText($"./Content/{ent.guid.id}.json", ent.SerializeToString());
        }

        public static T RegisterEntity<T>(T ent) where T : Core.Entity
        {
            if (ent.guid.id == 0 || Entities.ContainsKey(ent.guid.id))
            {
                uint newID;
                do newID = Hash.Generate.UInt32();
                while (Entities.ContainsKey(newID));
                ent.guid = new GUID(newID);
                Entities.Add(ent.guid.id, ent);
                return ent;
            }
            return default;
        }

        public static T LoadEntity<T>(T ent) where T : Core.Entity
        {
            Entities.Add(ent.guid.id, ent);
            return ent;
        }

        // async Task<T> DeleteEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static void DeleteEntity<T>(GUID guid) where T : Core.Entity
        {
            if (Entities.ContainsKey(guid.id))
                Entities.Remove(guid.id);
        }

        // async Task<T> LoadEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static T Get<T>(GUID guid) where T : Core.Entity
        {
            if (Entities.TryGetValue(guid.id, out var ent))
                return (T)ent;

            if (System.IO.File.Exists($"./Content/{guid.id}.json"))
                return LoadEntity(Serde.Deserialize.FromJson<T>(System.IO.File.ReadAllText($"./Content/{guid.id}.json")).data);

            return default;
        }

        // async Task<T> UnloadEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static void UnloadEntity<T>(GUID guid) where T : Core.Entity
        {
        }
    }
}