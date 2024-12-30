using VSect.Core;
using System.Collections.Generic;

namespace VSect.Object
{
    public class Container : Core.Object, I.Storage
    {
        public List<Ref<Item>> Items { get; set; }
    }
}