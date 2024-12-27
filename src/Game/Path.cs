namespace Game
{
    public static class Path
    {
        public static string Root => System.AppDomain.CurrentDomain.BaseDirectory;
        public static string Content => $"{Root}/Content";
    }
}