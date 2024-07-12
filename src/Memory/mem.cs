using System;
using System.Runtime.InteropServices;

namespace Memory;

unsafe public static class mem
{
    public static nint alloc(int size) => Marshal.AllocHGlobal(size);
    public static void free(nint ptr) => Marshal.FreeHGlobal(ptr);
    public static nint realloc(nint ptr, int size) => Marshal.ReAllocHGlobal(ptr, size);

    public static void alloc<T>(out arr<T> obj, int length) => obj = new arr<T>(length, sizeof(T));
    public static void free<T>(ref arr<T> obj) => obj.free();

    public static void alloc<T>(out T obj) where T : class
    {
        obj = default;
        TypedReference reference = __makeref(obj);
        *(nint*)*(nint*)&reference = alloc(sizeof(T));
        obj = __refvalue(reference, T);
    }

    public static void free<T>(ref T obj)
    {
        TypedReference reference = __makeref(obj);
        free(*(nint*)*(nint*)&reference);
    }

    public static void bind<T>(out T obj, nint ptr) where T : class
    {
        obj = default;
        TypedReference reference = __makeref(obj);
        *(nint*)*(nint*)&reference = ptr;
        obj = __refvalue(reference, T);
    }
}
