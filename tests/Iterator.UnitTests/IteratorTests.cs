namespace Iterator.UnitTests;

public class IteratorTests
{
    [Fact]
    public void SpanToIterator()
    {
        Span<int> span = stackalloc int[] { 1, 2, 3, 4, 5 };
        Iterator<int> iterator = span.ToIterator();
        Assert.Equal(span[0], iterator.Value);

        iterator = span.ToIterator(2);
        Assert.Equal(span[2], iterator.Value);
    }

    [Fact]
    public void ArrayToIterator()
    {
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        Iterator<int> iterator = array.ToIterator();
        Assert.Equal(array[0], iterator.Value);

        iterator = array.ToIterator(2);
        Assert.Equal(array[2], iterator.Value);
    }

    [Fact]
    public void SpanToIteratorRange()
    {
        Span<int> span = stackalloc int[] { 1, 2, 3, 4, 5 };
        IteratorRange<int> range = span.ToIteratorRange();
        Assert.Equal(span[0], range.First.Value);
        Assert.Equal(span[^1], range.Last.Value);

        range = span.ToIteratorRange(2, span.Length - 1);
        Assert.Equal(span[2], range.First.Value);
        Assert.Equal(span[^1], range.Last.Value);

        range = span.ToIteratorRange(1, 2);
        Assert.Equal(span[1], range.First.Value);
        Assert.Equal(span[2], range.Last.Value);

        var (first, last) = span.ToIteratorRange(1, 2);
        Assert.Equal(span[1], first);
        Assert.Equal(span[2], last);
    }

    [Fact]
    public void ArrayToIteratorRange()
    {
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        IteratorRange<int> range = array.ToIteratorRange();
        Assert.Equal(array[0], range.First.Value);
        Assert.Equal(array[^1], range.Last.Value);

        range = array.ToIteratorRange(2, array.Length - 1);
        Assert.Equal(array[2], range.First.Value);
        Assert.Equal(array[^1], range.Last.Value);

        range = array.ToIteratorRange(1, 3);
        Assert.Equal(array[1], range.First.Value);
        Assert.Equal(array[3], range.Last.Value);

        var (first, last) = array.ToIteratorRange(1, 2);
        Assert.Equal(array[1], first);
        Assert.Equal(array[2], last);
    }
}
