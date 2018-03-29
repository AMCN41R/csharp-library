# Examples

## String Extensions

### IsEmpty
Use this extension to check if a string is empty:
```csharp
string str;

if(str.IsEmpty())
{
    // ...
}
```

### IsNullOrEmpty
Use this extension method instead of `string.IsNullOrEmpty(str)`:
```csharp
string str;

// Instead of...
if(string.IsNullOrEmpty(str))
{
    // ...
}

// Use...
if(str.IsNullOrEmpty())
{
    // ...
}
```

### IsNullOrWhitespace
Use this extension method instead of `string.IsNullOrWhitespace(str)`:
```csharp
string str;

// Instead of...
if(string.IsNullOrWhitespace(str))
{
    // ...
}

// Use...
if(str.IsNullOrWhitespace())
{
    // ...
}
```
