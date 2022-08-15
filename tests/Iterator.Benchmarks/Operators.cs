using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using UnsafeHelper;

namespace Iterator.Benchmarks;

[DisassemblyDiagnoser]
public class Operators
{
    private int[]? _array;

    [GlobalSetup]
    public void SetupReverse()
    {
        _array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
    }

    [Benchmark]
    public nint Regular()
    {
        ref int first = ref MemoryMarshal.GetArrayDataReference(_array!);
        ref int second = ref Unsafe.Add(ref first, 1);
        return Unsafe.ByteOffset(ref second, ref first) / Unsafe.SizeOf<int>();
    }

    [Benchmark]
    public nint New()
    {
        (Iterator<int> first, Iterator<int> second) = _array!.ToIteratorRange(0, 1);
        return second - first;
    }
}
