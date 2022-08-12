using System.Runtime.CompilerServices;

namespace Yesmey;

public readonly ref struct IteratorRange<T>
{
    private readonly Iterator<T> _first;
    private readonly Iterator<T> _last;

    public IteratorRange(Iterator<T> first, Iterator<T> last)
    {
        _first = first;
        _last = last;
    }

    public Iterator<T> First => _first;

    public Iterator<T> Last => _last;

    public void Deconstruct(out Iterator<T> first, out Iterator<T> last)
    {
        first = _first;
        last = _last;
    }

    public Enumerator GetEnumerator() => new Enumerator(this);

    public ref struct Enumerator
    {
        private Iterator<T> _current;
        private readonly Iterator<T> _last;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Enumerator(IteratorRange<T> range)
        {
            _current = range._first - 1;
            _last = range._last;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            if (_current != _last)
            {
                _current++;
                return true;
            }

            return false;
        }

        public ref T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _current.Value;
        }
    }

    public override bool Equals(object? obj) => throw new NotImplementedException("Use the equality operator.");
    public override int GetHashCode() => throw new NotImplementedException("Cannot use GetHashCode");
}
