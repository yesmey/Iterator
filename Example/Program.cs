using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

{
    static void ClearBunchOfBytes(ref byte b)
    {
        Unsafe.As<byte, int>(ref b) = 0;
        Unsafe.As<byte, int>(ref Unsafe.Add(ref b, 4)) = 0;
        Unsafe.As<byte, int>(ref Unsafe.Add(ref b, 8)) = 0;
        Unsafe.As<byte, int>(ref Unsafe.Add(ref b, 12)) = 0;
        Unsafe.As<byte, short>(ref Unsafe.Add(ref b, 16)) = 0;
    }

    Span<byte> bytes = Enumerable.Range(0, 18).Select(x => (byte)x).ToArray();
    ClearBunchOfBytes(ref MemoryMarshal.GetReference(bytes));
    Console.WriteLine(string.Join(',', bytes.ToArray()));

    static void ClearBunchOfBytes2(ref byte b)
    {
        Iterator<byte> itr = new(ref b);
        ((Iterator<int>)itr).Value = 0;
        ((Iterator<int>)(itr + 4)).Value = 0;
        ((Iterator<int>)(itr + 8)).Value = 0;
        ((Iterator<int>)(itr + 12)).Value = 0;
        ((Iterator<short>)(itr + 16)).Value = 0;
    }

    Span<byte> bytes2 = Enumerable.Range(0, 18).Select(x => (byte)x).ToArray();
    ClearBunchOfBytes2(ref MemoryMarshal.GetReference(bytes2));
    Console.WriteLine(string.Join(',', bytes2.ToArray()));
}
