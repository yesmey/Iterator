using Yesmey;

namespace UnitTests;

public class IteratorCastTests
{
    [Fact]
    public void IntToByte()
    {
        int value = int.MaxValue;
        Iterator<int> a = new Iterator<int>(ref value);
        Assert.Equal(byte.MaxValue, ((Iterator<byte>)a).Value);
    }

    [Fact]
    public void IntToSByte()
    {
        int value = int.MaxValue;
        Iterator<int> a = new Iterator<int>(ref value);
        Assert.Equal((sbyte)-1, ((Iterator<sbyte>)a).Value);
    }

    [Fact]
    public void FloatToInt()
    {
        const int intValue = 123456789;
        float value = BitConverter.Int32BitsToSingle(intValue);
        Iterator<float> a = new Iterator<float>(ref value);
        Assert.Equal(intValue, ((Iterator<int>)a).Value);
    }

    [Fact]
    public void DoubleToLong()
    {
        const long longValue = 123456789;
        double value = BitConverter.Int64BitsToDouble(longValue);
        Iterator<double> a = new Iterator<double>(ref value);
        Assert.Equal(longValue, ((Iterator<long>)a).Value);
    }
}
