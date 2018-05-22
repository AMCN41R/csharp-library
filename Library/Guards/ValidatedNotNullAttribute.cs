namespace Library.Guards
{
    using System;

    /// <summary>
    /// When applied to a parameter, this attribute provides an indication
    /// to code analysis that the argument has been null checked.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}