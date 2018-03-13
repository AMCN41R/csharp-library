using System;

namespace Library.Guards
{
    /// <summary>
    /// When applied to a parameter, this attribute provides an indication 
    /// to code analysis that the argument has not been enumerated
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class NoEnumerationAttribute : Attribute
    {
    }
}