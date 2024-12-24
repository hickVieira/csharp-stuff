/*
- Json Files
- Files Version Conversion
- Manifest Files
- Manifest Master/Plugin Files
- Cell Object
- Cell Files
- Unity interop

loadorder.txt = plugin load order
/base
    base.json = manifest file
    player.json
    map.json
/dlc1
    dlc1.json
    santa.json
/mod1
    mod1.json
    pistol.json
*/

namespace Game.Base
{
    public class State
    {
        private Map<uint, Base.Entity> entities { get; set; } = new();

        public T RegisterEntity<T>(T ent) where T : Base.Entity
        {
            if (ent.guid.id == 0 || entities.ContainsKey(ent.guid.id))
            {
                uint newID;
                do newID = Hash.Generate.UInt32(Random.Int());
                while (entities.ContainsKey(newID));
                ent.guid = new GUID(newID);
                entities.Add(ent.guid.id, ent);
                return ent;
            }
            return default;
        }

        // async Task<T> DeleteObject<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public void DeleteObject<T>(GUID guid) where T : Base.Entity
        {
            if (entities.ContainsKey(guid.id))
                entities.Remove(guid.id);
        }

        // async Task<T> LoadObject<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public T Get<T>(GUID guid) where T : Base.Entity
        {
            if (entities.TryGetValue(guid.id, out var ent))
                return (T)ent;
            return default;
        }

        public I.Referenciable Get(GUID guid)
        {
            if (entities.TryGetValue(guid.id, out var ent))
                return ent;
            return default;
        }

        // async Task<T> UnloadObject<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
        public void UnloadObject<T>(GUID guid) where T : Base.Entity
        {
        }
    }
}