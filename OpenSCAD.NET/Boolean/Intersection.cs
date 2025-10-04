using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Boolean;

/// <summary>
/// Represents a boolean intersection operation between dimensional objects.
/// </summary>
public class Intersection<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Intersection{TUnit}"/> class.
    /// </summary>
    /// <param name="children">Objects to be intersected.</param>
    internal Intersection(params IDimensionalObject<TUnit>[] children)
    {
        Children = children;
    }

    /// <inheritdoc />
    public override string Name => "intersection";

    /// <inheritdoc />
    public override IDimensionalObject<TUnit>[] Children { get; }

    /// <inheritdoc />
    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

/// <summary>
/// Extension methods for creating intersection operations.
/// </summary>
public static class IntersectionExtensions
{
    /// <summary>
    /// Creates a boolean intersection operation between dimensional objects.
    /// </summary>
    /// <param name="object1">First object to be intersected.</param>
    /// <param name="objects">Further objects to be intersected.</param>
    /// <returns>
    /// New instance of <see cref="Intersection{TUnit}"/> representing the desired intersection operation.
    /// </returns>
    public static IDimensionalObject<TUnit> Intersect<TUnit>(this IDimensionalObject<TUnit> object1,
        params IDimensionalObject<TUnit>[] objects)
        where TUnit : IDimensionalUnit
    {
        return new Intersection<TUnit>([object1, ..objects]);
    }
}