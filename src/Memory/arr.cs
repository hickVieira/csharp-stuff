using System;

namespace Memory;

unsafe public struct arr<T>
{
    private nint Memory { get; set; }
    public int Length { get; private set; }
    private int Stride { get; set; }
    public T this[int index]
    {
        get
        {
            T obj = default;
            TypedReference reference = __makeref(obj);
            *(nint*)*(nint*)&reference = *(nint*)(Memory + index * Stride);
            return __refvalue(reference, T);
        }
        set
        {
            *(T*)(Memory + index * Stride) = value;
        }
    }

    public arr(int length, int stride)
    {
        Memory = mem.alloc(length * stride);
        Length = length;
        Stride = stride;
    }

    public void free()
    {
        mem.free(Memory);
        Memory = nint.Zero;
        Length = 0;
    }
}