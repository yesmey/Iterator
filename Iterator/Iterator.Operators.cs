using System.Runtime.CompilerServices;

namespace Yesmey;

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
