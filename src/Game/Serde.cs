using Game.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        static readonly System.Collections.Generic.Dictionary<string, Type> TypeMap =
                Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Entity).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .ToDictionary(t => t.FullName, t => t);

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
            public static void ToFile<T>(T obj) where T : I.Referenciable => System.IO.File.WriteAllText($"{obj.guid.id}.json", JsonConvert.SerializeObject(new Data<T>(obj), Formatting.Indented));
        }

        public static class Deserialize
        {
            public static Data<T> FromJson<T>(string json) => JsonConvert.DeserializeObject<Data<T>>(json, new EntityJsonConverterSwitch());
            public static Data<T> FromJson<T>(JObject json) => JsonConvert.DeserializeObject<Data<T>>(json.ToString(), new EntityJsonConverterSwitch());
            public static Entity FromJsonReflection(JObject json) => (Entity)json["data"].ToObject(TypeMap[json["type"].Value<string>()]);
            public static Entity FromJsonSwitch(string json) => JsonConvert.DeserializeObject<Entity>(json, new EntityJsonConverterSwitch());
            public static Entity FromJsonDict(string json) => JsonConvert.DeserializeObject<Entity>(json, new EntityJsonConverterDictionary());
        }

        public class EntityJsonConverterSwitch : JsonConverter<Data<Entity>>
        {
            public override void WriteJson(JsonWriter writer, Data<Entity> value, JsonSerializer serializer) => JObject.FromObject(value).WriteTo(writer);

            public override Data<Entity> ReadJson(JsonReader reader, Type objectType, Data<Entity> existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                var jsonObject = JObject.Load(reader);
                string type = jsonObject["type"].Value<string>();
                return type switch
                {
                    var v when v == typeof(Object.Ammo).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Ammo>()),
                    var v when v == typeof(Object.Ammo.Config).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Ammo.Config>()),
                    var v when v == typeof(Object.Character).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Character>()),
                    var v when v == typeof(Object.Character.Config).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Character.Config>()),
                    var v when v == typeof(Object.Container).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Container>()),
                    var v when v == typeof(Object.Equipment).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Equipment>()),
                    var v when v == typeof(Object.Gun).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Gun>()),
                    var v when v == typeof(Object.Gun.Config).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Gun.Config>()),
                    var v when v == typeof(Object.GunMod).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.GunMod>()),
                    var v when v == typeof(Object.GunMod.Config).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.GunMod.Config>()),
                    var v when v == typeof(Object.Item).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Item>()),
                    var v when v == typeof(Object.Prop).FullName => new Data<Entity>(jsonObject["data"].ToObject<Object.Prop>()),
                    _ => throw new JsonException($"Unknown type: {type}")
                };
            }
        }

        public class EntityJsonConverterDictionary : JsonConverter<Data<Entity>>
        {
            public override void WriteJson(JsonWriter writer, Data<Entity> value, JsonSerializer serializer) => JObject.FromObject(value).WriteTo(writer);

            public override Data<Entity> ReadJson(JsonReader reader, Type objectType, Data<Entity> existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                var jsonObject = JObject.Load(reader);
                string type = jsonObject["type"].Value<string>();
                return Game.TypeMap.Data[type](jsonObject["data"]!);
            }
        }
    }
}
