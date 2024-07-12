// using System;

// namespace bitwiseops;

// class Program
// {
// 	public static String GenerateBitfieldStringOfUInt32(uint32* pointer)
// 	{
// 		const uint32 size = 32;

// 		System.Collections.List<char8> charList = scope System.Collections.List<char8>();

// 		for (uint32 i = 0; i < size; i++)
// 		{
// 			uint32 mask = 1 << (size - i - 1);
// 			charList.Add((*pointer & mask) > 0 ? '1' : '0');
// 			if ((i + 1) % 8 == 0 && i < size - 1)
// 				charList.Add(' ');
// 		}
// 		charList.Add('\0');

// 		char8[] charArray = scope char8[charList.Count];
// 		charList.CopyTo(charArray);

// 		return new String(charArray, 0, charArray.Count);
// 	}

// 	public static String GenerateBitfieldStringOfInt32(int32* pointer)
// 	{
// 		const int32 size = 32;

// 		System.Collections.List<char8> charList = scope System.Collections.List<char8>();

// 		for (int32 i = 0; i < size; i++)
// 		{
// 			int32 mask = 1 << (size - i - 1);
// 			charList.Add((*pointer & mask) > 0 ? '1' : '0');
// 			if ((i + 1) % 8 == 0 && i < size - 1)
// 				charList.Add(' ');
// 		}
// 		charList.Add('\0');

// 		char8[] charArray = scope char8[charList.Count];
// 		charList.CopyTo(charArray);

// 		return new String(charArray, 0, charArray.Count);
// 	}

// 	public static String GenerateBitfieldStringOfFloat(uint32* pointer)
// 	{
// 		const uint32 size = 32;

// 		System.Collections.List<char8> charList = scope System.Collections.List<char8>();

// 		for (uint32 i = 0; i < size; i++)
// 		{
// 			charList.Add(((*pointer) & (1 << (size - i - 1))) > 0 ? '1' : '0');
// 			if (i == 0 || i == 8)
// 				charList.Add(' ');
// 		}
// 		charList.Add('\0');

// 		char8[] charArray = scope char8[charList.Count];
// 		charList.CopyTo(charArray);

// 		return new String(charArray, 0, charArray.Count);
// 	}

// 	public static void PrintNumberBits(uint32 number)
// 	{
// 		int32 asInt32 = *(int32*)&number;
// 		float asFloat = *(float*)&number;
// 		String str = GenerateBitfieldStringOfUInt32(&number);
// 		Console.WriteLine($"{str} \t uint:{number} \t int:{asInt32} \t float:{asFloat}");
// 		delete str;
// 	}

// 	public static void PrintNumberBits(int32 number)
// 	{
// 		uint32 asUInt32 = *(uint32*)&number;
// 		float asFloat = *(float*)&number;
// 		String str = GenerateBitfieldStringOfInt32(&number);
// 		Console.WriteLine($"{str} \t uint:{asUInt32} \t int:{number} \t float:{asFloat}");
// 		delete str;
// 	}

// 	public static void PrintNumberBits(float number)
// 	{
// 		uint32 asUInt32 = *(uint32*)&number;
// 		int32 asInt32 = *(int32*)&number;
// 		String str = GenerateBitfieldStringOfFloat(&asUInt32);
// 		Console.WriteLine($"{str} \t uint:{asUInt32} \t int:{asInt32} \t float:{number}");
// 		delete str;
// 	}

// 	public static void SplitFloat(float inFloat, out bool outIsNegative, out uint8 outExponent, out uint32 outMantissa)
// 	{
// 		uint32 asUInt32 = *(uint32*)&inFloat;
// 		outIsNegative = ((1 << 31) & asUInt32) > 0;
// 		outExponent = (uint8)((0x7f800000 & asUInt32) >> 23);
// 		outMantissa = 0x007fffff & asUInt32;
// 	}

// 	public static float CreateFloat(bool inIsNegative, uint8 inExponent, uint32 inMantissa)
// 	{
// 		uint32 outIsNegative = inIsNegative ? (1 << 31) : 0;
// 		uint32 outExponent = (uint32)((0x000000ff & inExponent) << 23);
// 		uint32 outMantissa = (uint32)(0x007fffff & inMantissa);
// 		uint32 outBitfield = outIsNegative | outExponent | outMantissa;
// 		return *(float*)&outBitfield;
// 	}

// 	public static void Main(String[] args)
// 	{
// 		float fA = -2f;
// 		uint32 iB = *(uint32*)&fA;
// 		uint32 iC = iB >> 1;
// 		float fC = *(float*)&iC;

// 		PrintNumberBits(1);
// 		PrintNumberBits(-1);
// 		PrintNumberBits(-2);
// 		PrintNumberBits(-4);
// 		PrintNumberBits(-8);
// 		PrintNumberBits(-0);
// 		PrintNumberBits(1f);
// 		PrintNumberBits(2f);
// 		PrintNumberBits(3f);
// 		PrintNumberBits(-0f);
// 		PrintNumberBits(CreateFloat(true, 1 << 7, 1 << 22));
// 		PrintNumberBits(CreateFloat(false, 1 << 7 | 1 << 6, 1 << 21));

// 		Console.WriteLine("end");
// 		Console.Read();
// 	}
// }