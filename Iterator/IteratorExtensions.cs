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

    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span)
        => new(span.ToIterator(), span.ToIterator(span.Length - 1));

    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span, int offset)
        => new(span.ToIterator(offset), span.ToIterator(span.Length - 1));

    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span, int offset, int length)
        => new(span.ToIterator(offset), span.ToIterator(offset + length));

    public static IteratorRange<T> ToIteratorRange<T>(this T[] array)
        => new(array.ToIterator(), array.ToIterator(array.Length - 1));

    public static IteratorRange<T> ToIteratorRange<T>(this T[] array, int offset)
        => new(array.ToIterator(offset), array.ToIterator(array.Length - 1));

    public static IteratorRange<T> ToIteratorRange<T>(this T[] array, int offset, int length)
        => new(array.ToIterator(offset), array.ToIterator(offset + length));
}
