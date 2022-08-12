using System.Runtime.CompilerServices;

namespace Yesmey;

public ref partial struct Iterator<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<bool>(Iterator<T> iterator)
            => CastToIterator<bool>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<byte>(Iterator<T> iterator)
        => CastToIterator<byte>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<sbyte>(Iterator<T> iterator)
        => CastToIterator<sbyte>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<char>(Iterator<T> iterator)
        => CastToIterator<char>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<ushort>(Iterator<T> iterator)
        => CastToIterator<ushort>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<short>(Iterator<T> iterator)
        => CastToIterator<short>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<uint>(Iterator<T> iterator)
        => CastToIterator<uint>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<int>(Iterator<T> iterator)
        => CastToIterator<int>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<ulong>(Iterator<T> iterator)
        => CastToIterator<ulong>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<long>(Iterator<T> iterator)
        => CastToIterator<long>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<nuint>(Iterator<T> iterator)
        => CastToIterator<nuint>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<nint>(Iterator<T> iterator)
        => CastToIterator<nint>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<float>(Iterator<T> iterator)
        => CastToIterator<float>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Iterator<double>(Iterator<T> iterator)
        => CastToIterator<double>(iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Iterator<TTo> CastToIterator<TTo>(Iterator<T> from)
        => new(ref Unsafe.As<T, TTo>(ref from._reference));
}