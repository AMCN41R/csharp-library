/*
 * This file is used by Code Analysis to maintain SuppressMessage
 * attributes that are applied to this project.
 * Project-level suppressions either have no target or are given
 * a specific target and scoped to a namespace, type, member, etc.
 */

#pragma warning disable SA1118 // Parameter must not span multiple lines

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1600:Elements must be documented",
    Justification = "Test methods don't need to be documented."
)]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage(
    "StyleCop.CSharp.ReadabilityRules",
    "SA1124:Do not use regions",
    Justification =
        "Regions provide useful groupings in test assemblies." +
        "They can be used to group all tests for each method being tested inside the given test file." +
        "It makes sure that all tests for a method are kept together, and makes it easier to see what is being tested and what tests are missing.")
]

#pragma warning restore SA1118 // Parameter must not span multiple lines