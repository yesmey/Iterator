using Yesmey;

namespace UnitTests;

public class IteratorRangeTests
{
    [Fact]
    public void Enumerator()
    {
        var array = new int[] { 1, 2, 3, 4, 5 };
        IteratorRange<int> ints = array.ToIteratorRange();
        int i = 0;
        foreach (int value in ints)
        {
            Assert.Equal(array[i], value);
            i++;
        }
        Assert.Equal(i, array.Length);
    }

    [Fact]
    public void RangeIteration()
    {
        var array = new int[] { 1, 2, 3, 4, 5 };
        int sum = 0;
        for (var (first, last) = array.ToIteratorRange(); first <= last; first++)
        {
            sum += first;
        }
        Assert.Equal(15, sum);
    }
}
