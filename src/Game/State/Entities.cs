/*
- Modules folder
- Modules manifest files
- Manifest files
- Manifest master/plugin files
- Cells
- Unity interop

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

using Game.Core;
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
                Entities.Add(ent.guid.id, ent);
            }
        }

        public static void Save()
        {
            foreach (var ent in Entities.Values)
                System.IO.File.WriteAllText($"{Path.Content}/{ent.guid.id}.json", ent.SerializeToJson());
        }

        public static T RegisterEntity<T>(T ent) where T : Entity
        {
            if (ent.guid.id == 0 || Entities.ContainsKey(ent.guid.id))
            {
                uint newID;
                do newID = Hash.Generate.UInt32();
                while (Entities.ContainsKey(newID));
                ent.guid = newID;
                Entities.Add(ent.guid.id, ent);
                return ent;
            }
            return default;
        }

        public static T LoadEntity<T>(T ent) where T : Entity
        {
            Entities.Add(ent.guid.id, ent);
            return ent;
        }

        // async Task<T> DeleteEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static void DeleteEntity<T>(GUID guid) where T : Entity
        {
            if (Entities.ContainsKey(guid.id))
                Entities.Remove(guid.id);
        }

        // async Task<T> LoadEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static T Get<T>(GUID guid) where T : Entity
        {
            if (Entities.TryGetValue(guid.id, out var ent))
                return (T)ent;

            if (System.IO.File.Exists($"{Path.Content}/{guid.id}.json"))
                return LoadEntity(Serde.Deserialize.FromJson<T>(System.IO.File.ReadAllText($"{Path.Content}/{guid.id}.json")).data);

            return default;
        }

        // async Task<T> UnloadEntity<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public static void UnloadEntity<T>(GUID guid) where T : Entity
        {
        }
    }
}