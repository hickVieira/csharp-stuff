// using System.Runtime.InteropServices;

// namespace Engine;

// public static class Utility
// {
// 	[StructLayout(LayoutKind.Sequential)]
// 	public struct SDL_Surface_Pixel8888
// 	{
// 		public ushort r;
// 		public ushort g;
// 		public ushort b;
// 		public ushort a;

// 		public SDL_Surface_Pixel8888(ushort r, ushort g, ushort b, ushort a)
// 		{
// 			this.r = r;
// 			this.g = g;
// 			this.b = b;
// 			this.a = a;
// 		}
// 	}

// 	[StructLayout(LayoutKind.Sequential)]
// 	public struct SDL_Texture_PixelRGB24
// 	{
// 		public ushort r;
// 		public ushort g;
// 		public ushort b;

// 		public SDL_Texture_PixelRGB24(ushort r, ushort g, ushort b)
// 		{
// 			this.r = r;
// 			this.g = g;
// 			this.b = b;
// 		}
// 	}

//     public static void PanicSDL() => System.Console.WriteLine($"SDL_ERROR: {SDL_GetError()}\n");

//     public static T Cast<T>(this nint pointer) => (T)Marshal.PtrToStructure(pointer, typeof(T));
// }