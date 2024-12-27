public static class Random
{
    public static int Int() => System.Guid.NewGuid().GetHashCode();
}