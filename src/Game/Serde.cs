using Game.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Game
{
    public static class Serde
    {
        private const uint _version = 0;

        public class Data<T>
        {
            public uint version { get; set; }
            public string type { get; set; }
            public T data { get; set; }
            public Data(T data) => (this.version, this.type, this.data) = (_version, data.GetType().FullName, data);
        }

        public static uint version(this JObject json) => json["version"].Value<uint>();
        public static string type(this JObject json) => json["type"].Value<string>();
        public static JToken data(this JObject json) => json["data"];

        public static class Parse
        {
            public static JObject Json(string json) => JObject.Parse(json);
        }

        public static class Serialize
        {
            public static string ToJson<T>(T obj) => JsonConvert.SerializeObject(new Data<T>(obj), Formatting.Indented);
            public static void ToFile<T>(T obj) where T : I.Referenciable => System.IO.File.WriteAllText($"{obj.guid}.json", JsonConvert.SerializeObject(new Data<T>(obj), Formatting.Indented));
        }

        public static class Deserialize
        {
            public static Data<T> FromJson<T>(string json) => JsonConvert.DeserializeObject<Data<T>>(json);
            public static Data<T> FromJson<T>(JObject json) => json.ToObject<Data<T>>();
            public static Data<Entity> FromJson(string json) => JsonConvert.DeserializeObject<Data<Entity>>(json, new EntityJsonConverter());
        }

        public class EntityJsonConverter : JsonConverter<Data<Entity>>
        {
            public override void WriteJson(JsonWriter writer, Data<Entity> value, JsonSerializer serializer) => JObject.FromObject(value).WriteTo(writer);

            public override Data<Entity> ReadJson(JsonReader reader, System.Type objectType, Data<Entity> existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                var jsonObject = JObject.Load(reader);
                string type = jsonObject["type"].Value<string>();
                return TypeMap.Data[type](jsonObject["data"]!);
            }
        }
    }
}