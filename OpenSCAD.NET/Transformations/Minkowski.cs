using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

/// <summary>
/// Represents a Minkowski sum operation that combines dimensional objects by adding their shapes together.
/// </summary>
public class Minkowski<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <summary>
    /// Gets the child objects to be included in the Minkowski sum operation.
    /// </summary>
    public override IDimensionalObject<TUnit>[] Children { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Minkowski{TUnit}"/> class with the specified children.
    /// </summary>
    /// <param name="children">The dimensional objects to include in the Minkowski sum operation.</param>
    internal Minkowski(params IDimensionalObject<TUnit>[] children)
    {
        Children = children;
    }

    /// <inheritdoc />
    public override string Name => "minkowski";

    /// <inheritdoc />
    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

/// <summary>
/// Extension methods for creating Minkowski sum operations.
/// </summary>
public static class MinkowskiExtensions
{
    /// <summary>
    /// Creates a Minkowski sum operation from one or more dimensional objects.
    /// </summary>
    /// <param name="obj">The first dimensional object.</param>
    /// <param name="others">Additional dimensional objects to include in the Minkowski sum operation.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Minkowski{TUnit}"/> instance representing the Minkowski sum of the provided objects.</returns>
    public static IDimensionalObject<TUnit> Minkowski<TUnit>(this IDimensionalObject<TUnit> obj,
        params IDimensionalObject<TUnit>[] others) where TUnit : IDimensionalUnit
    {
        return new Minkowski<TUnit>(new[] { obj }.Concat(others).ToArray());
    }
}