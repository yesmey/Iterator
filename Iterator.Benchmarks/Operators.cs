using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;
using Yesmey;

namespace Iterator.Benchmarks;

[DisassemblyDiagnoser]
public class Operators
{
    private int[] _array;

    [GlobalSetup]
    public void SetupReverse()
    {
        _array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
    }

    [Benchmark]
    public int Regular()
    {
        return (int)(Unsafe.ByteOffset(ref _array[1], ref _array[0]) / Unsafe.SizeOf<int>());
    }

    [Benchmark]
    public int New()
    {
        Iterator<int> first = new Iterator<int>(ref _array[0]);
        Iterator<int> second = new Iterator<int>(ref _array[1]);
        return second - first;
    }
}