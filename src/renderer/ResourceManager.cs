// using System.Collections.Generic;
// using static SDL2.SDL;

// namespace Engine;

// public class ResourceManager
// {
//     Dictionary<string, nint> _surfaces;

//     public ResourceManager()
//     {
//         _surfaces = new();
//     }

//     ~ResourceManager()
//     {
// 		foreach (var k in _surfaces.Keys)
//             SDL_FreeSurface(_surfaces[k]);
//     }

//     public SDL_Surface? GetSurface(string name)
//     {
//         nint surface;

//         if (!_surfaces.TryGetValue(name, out surface))
//         {
//             surface = SDL_LoadBMP(name);

//             if (surface == nint.Zero)
//             {
//                 System.Console.WriteLine($"Unable to load image {name}! SDL Error: {SDL_GetError()}\n");
//                 return null;
//             }

//             _surfaces.Add(name, surface);
//         }

//         return surface.Cast<SDL_Surface>();
//     }
// }
