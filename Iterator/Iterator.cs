using System.Runtime.CompilerServices;

namespace Yesmey;

public ref struct Iterator<T>
{
    private ref T _reference;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Iterator(Iterator<T> iterator)
    {
        _reference = ref iterator._reference;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Iterator(ref T reference)
    {
        _reference = ref reference;
    }

    public ref T Value => ref _reference;

    public ref T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Unsafe.Add(ref _reference, (nint)(uint)index);
        }
    }

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

    public override bool Equals(object? obj) => throw new NotImplementedException("Must use the equality operator");
    public override int GetHashCode() => throw new NotImplementedException("Cant use GetHashCode");
}
