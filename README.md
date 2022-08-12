## Introduction
A little experiment of implementing a C++-style iterator in C#.
It makes use of C# 11 preview that allows reference members in ref structs.

**This type is only intended for low-level use. Incorrect usage might corrupt memory or destabilize the .NET runtime**

------

### Iterator
```Iterator<T>``` is a stack allocated struct that only contains a reference to T;

```csharp
int val;
Iterator<int> iterator = new Iterator<int>(ref val);

Span<int> span;
Iterator<int> iterator = array.ToIterator();
//iterator == span[0];
```

```IteratorRange<T>``` is a helper struct that contains two ```Iterator<T>```'s pointing to the first and last location of a range;

```csharp
Span<int> span;
IteratorRange<int> range = span.ToIteratorRange();
//range.First == span[0];
//range.Last == span[^1];
```

### Usage
Imagine we have a Span-based Reverse method.
To prevent redundant out of bound checks we iterate with Unsafe.Add/Unsafe.Subtract. This will result in something like this:
```csharp
static void Reverse<T>(Span<T> span)
{
    if (span.Length <= 1)
        return;

    ref T first = ref MemoryMarshal.GetReference(span);
    ref T last = ref Unsafe.Subtract(ref Unsafe.Add(ref first, span.Length), 1);
    do
    {
        Swap(ref left, ref right);
        first = ref Unsafe.Add(ref first, 1);
        last = ref Unsafe.Subtract(ref last, 1);
    } while (Unsafe.IsAddressLessThan(ref first, ref last));

    static void Swap(ref T left, ref T right)
        => (left, right) = (right, left);
}
```

We can use Iterator<T> and IteratorRange<T> instead to move through the content with regular arithmetic operators.
```csharp
static void Reverse<T>(Span<T> span)
{
    if (span.Length <= 1)
        return;

    var (first, last) = span.ToIteratorRange();
    do
    {
        // .Value access the underlying value
        Swap(ref first.Value, ref last.Value);
        first++;
        last--;
    } while (left < right);

    static void Swap(ref T left, ref T right)
        => (left, right) = (right, left);
}
```

If we want to write the while loop as a oneliner, which would have been very difficult before
```csharp
do
{
    Swap(ref first.Value, ref last.Value);
} while (--left < ++right);
```

----

### Operators
Unsafe only have the methods IsSame/IsAddressGreaterThan/IsAddressLessThan to compare two references.

Here's some examples on how different operators are written in Unsafe.
```csharp
ref T left; ref T right;
// Equals
if (Unsafe.IsSame(ref left, ref right))
// GreaterThan
if (Unsafe.IsAddressGreaterThan(ref left, ref right))
// LessThan
if (Unsafe.IsAddressLessThan(ref left, ref right))
// GreaterThanOrEquals
if (!Unsafe.IsAddressLessThan(ref left, ref right))
// LessThanOrEquals
if (!Unsafe.IsAddressGreaterThan(ref left, ref right))
```

With Iterator<T> it looks like this:
```csharp
Iterator<T> left; Iterator<T> right;
// Equals
if (left == right)
// GreaterThan
if (left > right)
// LessThan
if (left < right)
// GreaterThanOrEquals
if (left >= right)
// LessThanOrEquals
if (left <= right)
```

----

### Casts
Iterator<T> can also be casted to a built-in type explicitly.
```csharp
Iterator<float> inputFloat;
Iterator<int> inputInt = (Iterator<int>)inputFloat; // Same as Unsafe.As<float, int>
```
