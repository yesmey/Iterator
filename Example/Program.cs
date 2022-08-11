using Yesmey;

// Example on how to implement a Reverse function
{
    Span<int> ints = Enumerable.Range(0, 50).ToArray();
    Reverse(ints);
    Console.WriteLine(string.Join(',', ints.ToArray()));

    static void Reverse<T>(Span<T> span)
    {
        if (span.Length <= 1)
            return;

        Iterator<T> left = span.ToIterator();
        Iterator<T> right = span.ToIterator(span.Length - 1);
        do
        {
            Swap(ref left.Value, ref right.Value);
        } while (++left < --right);

        static void Swap(ref T left, ref T right)
            => (left, right) = (right, left);
    }
}

// Example on how to implement a Fill function
{
    Span<int> ints = Enumerable.Range(0, 50).ToArray();
    Fill(ints, -1);
    Console.WriteLine(string.Join(',', ints.ToArray()));

    static void Fill<T>(Span<T> span, T value)
    {
        Iterator<T> current = span.ToIterator();
        Iterator<T> last = span.ToIterator(span.Length - 1);

        while (current <= last)
        {
            current.Value = value;
            current++;
        }
    }
}
