namespace Game.Core
{
    public class Manifest
    {
        public class Entry
        {
            public string Path { get; set; }
        }
        public Map<uint, Entry> entries { get; set; }

        public void Insert(string path)
        {
        }
    }
}