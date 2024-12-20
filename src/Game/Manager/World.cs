namespace Game.Manager;

public static class World
{
    public static Base.Entity[] entities { get; set; }

    public static Map<uint, Base.Entity> idMap = new();

    public static T RegisterEntity<T>(T ent) where T : Base.Entity
    {
        if (ent.guid.id == 0 || idMap.ContainsKey(ent.guid.id))
        {
            uint newID;
            do newID = Hash.Generate.UInt32(Random.Int());
            while (idMap.ContainsKey(newID));
            ent.guid = new GUID(newID);
            idMap.Add(ent.guid.id, ent);
            return ent;
        }

        return default;
    }

    // async Task<T> DeleteObject<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
    public static void DeleteObject<T>(GUID guid) where T : Base.Entity
    {
        if (idMap.ContainsKey(guid.id))
            idMap.Remove(guid.id);
    }

    // async Task<T> LoadObject<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
    public static T Get<T>(GUID guid) where T : Base.Entity
    {
        if (idMap.TryGetValue(guid.id, out var ent))
            return (T)ent;
        return default;
    }

    public static I.Referenciable Get(GUID guid)
    {
        if (idMap.TryGetValue(guid.id, out var ent))
            return ent;
        return default;
    }

    // async Task<T> UnloadObject<T>(guid guid) where T : Base.Entity => await Task.FromResult<T>(default);
    public static void UnloadObject<T>(GUID guid) where T : Base.Entity
    {
    }
}