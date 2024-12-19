using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

public static class Extensions
{
    public static int ReadVersionFromJson(string jsonString)
    {
        if (JObject.Parse(jsonString).TryGetValue("version", out var version))
            return version.Value<int>();
        else
            return -1;
    }

    public static string SerializeToString<T>(this T obj) => JsonConvert.SerializeObject(obj);
    public static byte[] SerializeToBytes<T>(this T obj) => Encoding.UTF8.GetBytes(obj.SerializeToString());
    public static T DeserializeFromString<T>(string str) => JsonConvert.DeserializeObject<T>(str);
    public static T DeserializeFromBytes<T>(byte[] data) => DeserializeFromString<T>(Encoding.UTF8.GetString(data));
}