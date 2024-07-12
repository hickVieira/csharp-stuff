namespace GUID;

public static class guid
{
    public enum Type
    {
        AlphanumericAll,
        AlphanumericUpper,
        AlphanumericLower,
        HexadecimalUpper,
        HexadecimalLower,
        Octal,
    }

    const string _alphanumericsAll = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    const string _alphanumericsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    const string _alphanumericsLower = "abcdefghijklmnopqrstuvwxyz0123456789";
    const string _hexadecimalsUpper = "0123456789ABCDEF";
    const string _hexadecimalsLower = "0123456789abcdef";
    const string _octals = "01234567";

    public static string rand(Type type, uint length, System.Random random)
    {
        string symbols = string.Empty;
        switch (type)
        {
            case Type.AlphanumericAll:
                symbols = _alphanumericsAll;
                break;
            case Type.AlphanumericUpper:
                symbols = _alphanumericsUpper;
                break;
            case Type.AlphanumericLower:
                symbols = _alphanumericsLower;
                break;
            case Type.HexadecimalUpper:
                symbols = _hexadecimalsUpper;
                break;
            case Type.HexadecimalLower:
                symbols = _hexadecimalsLower;
                break;
            case Type.Octal:
                symbols = _octals;
                break;
        }

        char[] output = new char[length];
        for (uint i = 0; i < length; i++)
        {
            int index = random.Next(symbols.Length);
            output[i] = symbols[index];
        }

        return new string(output);
    }

    // high entropy
    // 4 bytes collision ratio: ~0/100k
    // slow
    public static byte[] sha512(byte[] inputBytes)
    {
        using (var sha512 = System.Security.Cryptography.SHA512.Create())
            return sha512.ComputeHash(inputBytes);
    }

    // medium entropy
    // 4 bytes collision ratio: ~1/100k
    // super fast (~0ms at 1M)
    public static uint fnv32(byte[] inputBytes)
    {
        const uint fnv_offset_basis = 0x811c9dc5;
        const uint fnv_prime = 0x01000193;
        uint hash = fnv_offset_basis;

        for (uint i = 0; i < inputBytes.Length; i++)
        {
            hash ^= inputBytes[i];
            hash *= fnv_prime;
        }
        
        return hash;
    }
}