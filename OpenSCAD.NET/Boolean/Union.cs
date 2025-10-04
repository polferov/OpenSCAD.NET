using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Boolean;

/// <summary>
/// Represents a boolean union operation between dimensional objects.
/// </summary>
public class Union<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Union{TUnit}"/> class.
    /// </summary>
    /// <param name="children">Objects to be united.</param>
    internal Union(params IDimensionalObject<TUnit>[] children)
    {
        Children = children;
    }

    /// <inheritdoc />
    public override string Name => "union";

    /// <inheritdoc />
    public override IDimensionalObject<TUnit>[] Children { get; }

    /// <inheritdoc />
    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

/// <summary>
/// Extension methods for creating union operations.
/// </summary>
public static class UnionExtensions
{
    /// <summary>
    /// Creates a boolean union operation between dimensional objects.
    /// </summary>
    /// <param name="object1">First object to be united.</param>
    /// <param name="objects">Further objects to be united.</param>
    /// <returns>
    /// New instance of <see cref="Union{TUnit}"/> representing the desired union operation.
    /// </returns>
    public static IDimensionalObject<TUnit> Union<TUnit>(this IDimensionalObject<TUnit> object1,
        params IDimensionalObject<TUnit>[] objects)
        where TUnit : IDimensionalUnit
    {
        return new Union<TUnit>([object1, ..objects]);
    }
}