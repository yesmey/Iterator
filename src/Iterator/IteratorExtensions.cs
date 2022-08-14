using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Yesmey;

public static class IteratorExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> ToIterator<T>(this Span<T> span)
        => new(ref MemoryMarshal.GetReference(span));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> ToIterator<T>(this Span<T> span, int offset)
        => new(ref Unsafe.Add(ref MemoryMarshal.GetReference(span), offset));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> ToIterator<T>(this T[] array)
        => new(ref MemoryMarshal.GetArrayDataReference(array));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> ToIterator<T>(this T[] array, int offset)
        => new(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), offset));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span)
    {
        ref T first = ref MemoryMarshal.GetReference(span);
        ref T last = ref Unsafe.Subtract(ref Unsafe.Add(ref first, span.Length), 1);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span, int offset)
    {
        ref T first = ref MemoryMarshal.GetReference(span);
        ref T last = ref Unsafe.Add(ref first, offset);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this Span<T> span, int offset, int length)
    {
        ref T first = ref MemoryMarshal.GetReference(span);
        ref T last = ref Unsafe.Add(ref Unsafe.Add(ref first, offset), length);
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
    public static IteratorRange<T> ToIteratorRange<T>(this T[] array, int offset)
    {
        ref T first = ref MemoryMarshal.GetArrayDataReference(array);
        ref T last = ref Unsafe.Subtract(ref Unsafe.Add(ref first, offset), 1);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IteratorRange<T> ToIteratorRange<T>(this T[] array, int offset, int length)
    {
        ref T first = ref MemoryMarshal.GetArrayDataReference(array);
        ref T last = ref Unsafe.Add(ref Unsafe.Add(ref first, offset), length);
        return new IteratorRange<T>(new Iterator<T>(ref first), new Iterator<T>(ref last));
    }
}
