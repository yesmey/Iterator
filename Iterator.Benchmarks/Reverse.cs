using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Yesmey;

namespace Iterator.Benchmarks;

[DisassemblyDiagnoser]
public class Reverse
{
    private int[] _array;

    [GlobalSetup]
    public void SetupReverse() => _array = Enumerable.Range(0, 1000).ToArray();

    [Benchmark]
    public void Regular()
    {
        Reverse(_array.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void Reverse<T>(Span<T> span)
        {
            if (span.Length <= 1)
                return;

            ref T first = ref MemoryMarshal.GetReference(span);
            ref T last = ref Unsafe.Subtract(ref Unsafe.Add(ref first, span.Length), 1);
            do
            {
                Swap<T>(ref first, ref last);
                first = ref Unsafe.Add(ref first, 1);
                last = ref Unsafe.Subtract(ref last, 1);
            } while (Unsafe.IsAddressLessThan(ref first, ref last));
        }
    }

    [Benchmark]
    public void New()
    {
        Reverse(_array.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void Reverse<T>(Span<T> span)
        {
            if (span.Length <= 1)
                return;

            var (first, last) = span.ToIteratorRange();
            do
            {
                Swap(ref first.Value, ref last.Value);
            } while (++first < --last);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Swap<T>(ref T left, ref T right)
        => (left, right) = (right, left);
}
