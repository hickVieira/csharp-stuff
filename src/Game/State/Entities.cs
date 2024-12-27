using Game.Core;
using System;
using System.Collections.Generic;

namespace Game
{
    public static class State
    {
        public static Dictionary<uint, Entity> Entities { get; private set; } = new();

        public static void Load()
        {
            Entities.Clear();
            foreach (var file in System.IO.Directory.EnumerateFiles($"{Path.Content}"))
            {
                var jsonString = System.IO.File.ReadAllText(file);
                var ent = Serde.Deserialize.FromJson(jsonString).data;
                ent.guid = uint.Parse(System.IO.Path.GetFileNameWithoutExtension(file));
                Entities.Add(ent.guid, ent);
            }
        }

        public static void Save()
        {
            foreach (var ent in Entities.Values)
                System.IO.File.WriteAllText($"{Path.Content}/{ent.guid}.json", ent.SerializeToJson());
        }

        public static T RegisterEntity<T>(T ent) where T : Entity
        {
            if (ent.guid == 0 || Entities.ContainsKey(ent.guid))
            {
                uint newID;
                do newID = Hash.Generate.UInt32();
                while (newID == 0 || Entities.ContainsKey(newID));
                ent.guid = newID;
                Entities.Add(ent.guid, ent);
                return ent;
            }
            return default;
        }

        // async Task<T> DeleteEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static void DeleteEntity<T>(uint guid) where T : Entity
        {
            if (Entities.ContainsKey(guid))
                Entities.Remove(guid);
        }

        // async Task<T> LoadEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static T Get<T>(uint guid) where T : Entity
        {
            if (Entities.TryGetValue(guid, out var ent))
                return (T)ent;

            if (System.IO.File.Exists($"{Path.Content}/{guid}.json"))
            {
                ent = Serde.Deserialize.FromJson<T>(System.IO.File.ReadAllText($"{Path.Content}/{guid}.json")).data;
                ent.guid = guid;
                Entities.Add(ent.guid, ent);
                return (T)ent;
            }

            return default;
        }

        // async Task<T> UnloadEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static void UnloadEntity<T>(uint guid) where T : Entity
        {
        }
    }
}