using Newtonsoft.Json;

namespace Game.Object;

public class Ammo : Core.Object, I.Named
{
    public class Config : Core.Config
    {
        public string Name { get; set; }
        public uint ProjectilesCount { get; set; }
    }
    public Ref<Config> config { get; set; }

    [JsonIgnore] public string Name { get => config.entity.Name; }
}