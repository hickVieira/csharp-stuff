// using Silk.NET.Maths;
// using Silk.NET.Windowing;

// namespace Engine;

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         WindowOptions options = WindowOptions.Default with
//         {
//             Size = new Vector2D<int>(800, 600),
//             Title = "Hello Pixel",
//         };
//         var window = Window.Create(options);
//         window.Run();

//         // paint pixel red

//     }
// }

// using System;
// using static SDL2.SDL;

// namespace Engine;

// public class Program
// {
//     static nint _window;
//     static nint _surface;
//     static ResourceManager _resourceManager;

//     public static void Main(string[] args)
//     {
//         // Initialize SDL
//         if (SDL_Init(SDL_INIT_VIDEO) < 0)
//         {
//             Console.WriteLine($"SDL_ERROR: {SDL_GetError()}\n");
//             return;
//         }

//         // Create window
//         _window = SDL_CreateWindow("Hello Pixel", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, 800, 600, SDL_WindowFlags.SDL_WINDOW_SHOWN);
//         if (_window == nint.Zero)
//         {
//             Console.WriteLine($"SDL_ERROR: {SDL_GetError()}\n");
//             return;
//         }

//         // Create surface
//         _surface = SDL_GetWindowSurface(_window);
//         if (_surface == nint.Zero)
//         {
//             Console.WriteLine($"SDL_ERROR: {SDL_GetError()}\n");
//             return;
//         }

//         // Update the surface
//         SDL_UpdateWindowSurface(_window);

//         // Create managers
//         _resourceManager = new();

//         // Main loop
//         Run();

//         SDL_DestroyWindow(_window);
//         SDL_Quit();
//     }

//     public static int GetPixelIndex(int x, int y, int pitch)
//     {
//         return (x + y * pitch);
//     }

//     public static void Run()
//     {
//         SDL_Event e;
//         while (true)
//         {
//             SDL_PollEvent(out e);

//             if (e.type == SDL_EventType.SDL_QUIT)
//                 return;

//             SDL_LockSurface(_surface);
//             {
//                 Random rand = new Random();

//                 var surface = _surface.Cast<SDL_Surface>();

//                 unsafe
//                 {
//                     Utility.SDL_Surface_Pixel8888* pixels = (Utility.SDL_Surface_Pixel8888*)surface.pixels;

//                     for (int x = 0; x < surface.w; x++)
//                         for (int y = 0; y < surface.h; y++)
//                             pixels[GetPixelIndex(x, y, surface.w)] = new Utility.SDL_Surface_Pixel8888((ushort)rand.Next(0, 255), (ushort)rand.Next(0, 255), (ushort)rand.Next(0, 255), (ushort)rand.Next(0, 255));
//                 }
//             }
//             SDL_UnlockSurface(_surface);

//             SDL_UpdateWindowSurface(_window);

//             // update
//             // SDL_UpdateTexture(_texture, null, _pixels, SCREEN_WIDTH * 4);
//             // SDL_RenderCopyEx(_renderer, _texture, null, null, 0, null, .Vertical);
//             // SDL_RenderPresent(_renderer);
//         }
//     }
// }
