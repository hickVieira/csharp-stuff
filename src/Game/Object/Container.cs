using Game.Core;
using System.Collections.Generic;

namespace Game.Object
{
    public class Container : Core.Object, I.Storage
    {
        public List<Ref<Item>> Items { get; set; }
    }
}