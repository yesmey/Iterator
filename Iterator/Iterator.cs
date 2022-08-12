using System.Runtime.CompilerServices;

namespace Yesmey;

public ref partial struct Iterator<T>
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

    public override bool Equals(object? obj) => throw new NotImplementedException("Must use the equality operator");
    public override int GetHashCode() => throw new NotImplementedException("Cant use GetHashCode");
}
