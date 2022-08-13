namespace Iterator.UnitTests;

public class IteratorOperatorTests
{
    [Fact]
    public void IncrementOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator();
        Assert.Equal(1, a);
        a++;
        Assert.Equal(2, a);
    }

    [Fact]
    public void AdditionOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator();
        Assert.Equal(1, a);
        a += 2;
        Assert.Equal(3, a);
    }

    [Fact]
    public void DecrementOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator(1);
        Assert.Equal(2, a);
        a--;
        Assert.Equal(1, a);
    }

    [Fact]
    public void SubtractionOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator(2);
        Assert.Equal(3, a);
        a -= 2;
        Assert.Equal(1, a);
    }

    [Fact]
    public void LesserThanOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator(1);
        Iterator<int> b = input.ToIterator(2);
        Assert.True(a < b);
    }

    [Fact]
    public void GreaterThanOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator(2);
        Iterator<int> b = input.ToIterator(1);
        Assert.True(a > b);
    }

    [Fact]
    public void LesserThanEqualsOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator(1);
        Iterator<int> b = input.ToIterator(2);
        Assert.True(a <= b);
        a++;
        Assert.True(a <= b);
    }

    [Fact]
    public void GreaterThanEqualsOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator(2);
        Iterator<int> b = input.ToIterator(1);
        Assert.True(a >= b);
        b++;
        Assert.True(a >= b);
    }

    [Fact]
    public void EqualityThanOperator()
    {
        Span<int> input = stackalloc int[] { 1, 2, 3 };
        Iterator<int> a = input.ToIterator();
        Iterator<int> b = input.ToIterator();
        Assert.True(a == b);
        Assert.False(a != b);
        a++;
        Assert.False(a == b);
        Assert.True(a != b);
    }
}
