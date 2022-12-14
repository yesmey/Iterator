using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnsafeHelper;

public static class IteratorExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> ToIterator<T>(this Span<T> span)
        => new(ref MemoryMarshal.GetReference(span));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> ToIterator<T>(this Span<T> span, nuint offset)
        => new(ref Unsafe.Add(ref MemoryMarshal.GetReference(span), offset));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> ToIterator<T>(this T[] array)
        => new(ref MemoryMarshal.GetArrayDataReference(array));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> ToIterator<T>(this T[] array, nuint offset)
        => new(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), offset));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span)
    {
        ref T first = ref MemoryMarshal.GetReference(span);
        ref T last = ref Unsafe.Subtract(ref Unsafe.Add(ref first, span.Length), 1);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span, nuint offset)
    {
        ref T first = ref MemoryMarshal.GetReference(span);
        ref T last = ref Unsafe.Add(ref first, offset);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span, nuint startOffset, nuint endOffset)
    {
        ref T first = ref Unsafe.Add(ref MemoryMarshal.GetReference(span), startOffset);
        ref T last = ref Unsafe.Add(ref first, endOffset - startOffset);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this T[] array)
    {
        ref T first = ref MemoryMarshal.GetArrayDataReference(array);
        ref T last = ref Unsafe.Subtract(ref Unsafe.Add(ref first, array.Length), 1);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this T[] array, nuint startOffset, nuint endOffset)
    {
        ref T first = ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), startOffset);
        ref T last = ref Unsafe.Add(ref first, endOffset - startOffset);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }
}
