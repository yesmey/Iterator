using System.Runtime.CompilerServices;

namespace UnsafeHelper;

public ref partial struct Iterator<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T(Iterator<T> iterator)
        => iterator._reference;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Iterator<T> left, Iterator<T> right)
        => !(left == right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Iterator<T> left, Iterator<T> right)
        => Unsafe.AreSame(ref left._reference, ref right._reference);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Iterator<T> left, Iterator<T> right)
        => Unsafe.IsAddressGreaterThan(ref left._reference, ref right._reference);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Iterator<T> left, Iterator<T> right)
        => !(left < right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Iterator<T> left, Iterator<T> right)
        => Unsafe.IsAddressLessThan(ref left._reference, ref right._reference);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Iterator<T> left, Iterator<T> right)
        => !(left > right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> operator ++(Iterator<T> iterator)
    {
        iterator._reference = ref Unsafe.Add(ref iterator._reference, 1);
        return iterator;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> operator +(Iterator<T> iterator, int offset)
    {
        iterator._reference = ref Unsafe.Add(ref iterator._reference, offset);
        return iterator;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> operator +(Iterator<T> iterator, nuint offset)
    {
        iterator._reference = ref Unsafe.Add(ref iterator._reference, offset);
        return iterator;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> operator --(Iterator<T> iterator)
    {
        iterator._reference = ref Unsafe.Subtract(ref iterator._reference, 1);
        return iterator;
    }

    /// <summary>
    /// Determines the byte offset between origin and target
    /// </summary>
    /// <param name="left">The iterator to the origin</param>
    /// <param name="right">The iterator to the target</param>
    /// <returns>The byte offset from origin to target</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int operator -(Iterator<T> origin, Iterator<T> target)
    {
        // ByteOffset input is reversed
        return (int)((nuint)Unsafe.ByteOffset(ref target._reference, ref origin._reference) / (nuint)Unsafe.SizeOf<T>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> operator -(Iterator<T> iterator, int offset)
    {
        iterator._reference = ref Unsafe.Subtract(ref iterator._reference, offset);
        return iterator;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Iterator<T> operator -(Iterator<T> iterator, nuint offset)
    {
        iterator._reference = ref Unsafe.Subtract(ref iterator._reference, offset);
        return iterator;
    }
}
