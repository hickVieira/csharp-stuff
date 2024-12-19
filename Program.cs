using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

static class Program
{
    static void Main()
    {
        // GUID.test.run();
        // Memory.test.run();
        // Jobs.test.run();
        // Game.Base.Gun gun = new Game.Base.Gun();
        // Console.WriteLine(gun.Serialize());
        // Console.WriteLine(Convert.ToBase64String(gun.SerializeToBytes()));
        // Console.WriteLine(gun.SerializeToString());
        Game.Entity.Character ent = new Game.Entity.Character();
        Console.WriteLine(ent.Serialize());
        Console.WriteLine(ent.SerializeVersioned(1));
        // Console.WriteLine(Convert.ToBase64String(ent.SerializeToBytes()));
        // Console.WriteLine(ent.Serialize());
    }
}
