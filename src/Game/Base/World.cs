namespace Game.Base;

public class World : I.World, I.Serializable
{
    public string SerializeToString() => Formatter.Serialize.ToString(this);
    public string SerializeToStringVersioned(uint version) => Formatter.Serialize.ToStringVersioned(version, this);

    public Object[] objects { get; set; }

    public Map<uint, Object> idMap = new();

    public T RegisterObject<T>(T obj) where T : Object
    {
        if (obj.guid.id == 0 || idMap.ContainsKey(obj.guid.id))
        {
            uint newID;
            do newID = Hash.Generate.UInt32(Random.Int());
            while (idMap.ContainsKey(newID));
            obj.guid = new GUID(newID);
            idMap.Add(obj.guid.id, obj);
            return obj;
        }

        return default;
    }

    public void DeleteObject<T>(GUID guid) where T : Object
    {
        if (idMap.ContainsKey(guid.id))
            idMap.Remove(guid.id);
    }

    public T LoadObject<T>(GUID guid) where T : Object
    {
        if (idMap.TryGetValue(guid.id, out var obj))
            return (T)obj;
        return default;
    }

    public void UnloadObject<T>(GUID guid) where T : Object
    {
    }
}