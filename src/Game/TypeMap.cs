using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Game
{
    public static class TypeMap
    {
        public readonly static Dictionary<string, System.Func<JToken, Serde.Data<Core.Entity>>> Data = new()
        {
            {typeof(Object.Ammo).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Ammo>())},
            {typeof(Object.Ammo.Config).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Ammo.Config>())},
            {typeof(Object.Cell).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Cell>())},
            {typeof(Object.Character).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Character>())},
            {typeof(Object.Character.Config).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Character.Config>())},
            {typeof(Object.Container).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Container>())},
            {typeof(Object.Equipment).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Equipment>())},
            {typeof(Object.Gun).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Gun>())},
            {typeof(Object.Gun.Config).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Gun.Config>())},
            {typeof(Object.GunMod).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.GunMod>())},
            {typeof(Object.GunMod.Config).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.GunMod.Config>())},
            {typeof(Object.Item).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Item>())},
            {typeof(Object.Prop).FullName!, data => new Serde.Data<Core.Entity>(data.ToObject<Object.Prop>())},
        };
    }
}