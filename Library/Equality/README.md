# Examples

## Generic Comparer

Given the following class...
```csharp
public class Person
{
    public string Name { get; set; }

    public int Age { get; set; }
}
```

Create a comparer like this...
```csharp
public IEqualityComparer<Person> PersonComparer()
{
    return new GenericComparer<Person>(
        (x, y) => x.Name == y.Name,
        (x, y) => x.Age == y.Age
    );
}
```

And use it anywhere that takes and `IEqualityComparer<T>`, for example, in an XUnit test...
```csharp
Assert.Equal(
    expectedPerson,
    actualPerson,
    new PersonComparer()
);
```

## Comparer Factory

Given the same `Person` class, you can use the `ComparerFactory` to generate a comparer...

```csharp
var comparer = ComparerFactory.GetComparer<Person>();
```

And use it anywhere that takes and `IEqualityComparer<T>`, for example, in an XUnit test...
```csharp
Assert.Equal(
    expectedPerson,
    actualPerson,
    ComparerFactory.GetComparer<Person>()
);
```