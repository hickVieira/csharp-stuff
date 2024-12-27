public static class Hash
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
    static int _seed = int.MinValue;

    public static class Generate
    {
        public static string String(Type type, uint length, System.Random random)
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

        public static System.Int16 Int16() => System.Convert.ToInt16(Generate.String(Hash.Type.HexadecimalUpper, 4, new System.Random(_seed++)), 16);
        public static System.Int32 Int32() => System.Convert.ToInt32(Generate.String(Hash.Type.HexadecimalUpper, 8, new System.Random(_seed++)), 16);
        public static System.Int64 Int64() => System.Convert.ToInt64(Generate.String(Hash.Type.HexadecimalUpper, 16, new System.Random(_seed++)), 16);
        public static System.UInt16 UInt16() => System.Convert.ToUInt16(Generate.String(Hash.Type.HexadecimalUpper, 4, new System.Random(_seed++)), 16);
        public static System.UInt32 UInt32() => System.Convert.ToUInt32(Generate.String(Hash.Type.HexadecimalUpper, 8, new System.Random(_seed++)), 16);
        public static System.UInt64 UInt64() => System.Convert.ToUInt64(Generate.String(Hash.Type.HexadecimalUpper, 16, new System.Random(_seed++)), 16);
    }
}