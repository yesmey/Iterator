using System.Runtime.InteropServices;

namespace Yesmey;

public static class IteratorExtensions
{
    public static Iterator<T> ToIterator<T>(this Span<T> span)
        => new(ref MemoryMarshal.GetReference(span));

    public static Iterator<T> ToIterator<T>(this Span<T> span, int offset)
        => new(ref span[offset]);

    public static Iterator<T> ToIterator<T>(this T[] array)
        => new(ref MemoryMarshal.GetArrayDataReference(array));

    public static Iterator<T> ToIterator<T>(this T[] array, int offset)
        => new(ref array[offset]);
}
