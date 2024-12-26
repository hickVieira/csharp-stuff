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
                    var v when v == typeof(Game.Object.Ammo).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Ammo>()),
                    var v when v == typeof(Game.Object.Ammo.Config).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Ammo.Config>()),
                    var v when v == typeof(Game.Object.Character).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Character>()),
                    var v when v == typeof(Game.Object.Character.Config).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Character.Config>()),
                    var v when v == typeof(Game.Object.Container).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Container>()),
                    var v when v == typeof(Game.Object.Equipment).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Equipment>()),
                    var v when v == typeof(Game.Object.Gun).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Gun>()),
                    var v when v == typeof(Game.Object.Gun.Config).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Gun.Config>()),
                    var v when v == typeof(Game.Object.GunMod).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.GunMod>()),
                    var v when v == typeof(Game.Object.GunMod.Config).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.GunMod.Config>()),
                    var v when v == typeof(Game.Object.Item).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Item>()),
                    var v when v == typeof(Game.Object.Prop).FullName => new Data<Entity>(jsonObject["data"].ToObject<Game.Object.Prop>()),
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
                var typeMap = new Dictionary<string, Func<JToken, Data<Entity>>>
            {
                { typeof(Game.Object.Ammo).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Ammo>())},
                { typeof(Game.Object.Ammo.Config).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Ammo.Config>())},
                { typeof(Game.Object.Character).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Character>())},
                { typeof(Game.Object.Character.Config).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Character.Config>())},
                { typeof(Game.Object.Container).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Container>())},
                { typeof(Game.Object.Equipment).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Equipment>())},
                { typeof(Game.Object.Gun).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Gun>())},
                { typeof(Game.Object.Gun.Config).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Gun.Config>())},
                { typeof(Game.Object.GunMod).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.GunMod>())},
                { typeof(Game.Object.GunMod.Config).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.GunMod.Config>())},
                { typeof(Game.Object.Item).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Item>())},
                { typeof(Game.Object.Prop).FullName!, data => new Data<Entity>(data.ToObject<Game.Object.Prop>())},
            };
                if (typeMap.TryGetValue(type, out var factory))
                    return factory(jsonObject["data"]!);
                return default;
            }
        }
    }
}
