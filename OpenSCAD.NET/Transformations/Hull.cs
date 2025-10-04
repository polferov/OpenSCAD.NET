using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

/// <summary>
/// Represents a hull operation that computes the convex hull of its child dimensional objects.
/// </summary>
public class Hull<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <inheritdoc />
    public override string Name => "hull";

    /// <summary>
    /// Gets the child objects to be included in the hull operation.
    /// </summary>
    public override IDimensionalObject<TUnit>[] Children { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Hull{TUnit}"/> class with the specified children.
    /// </summary>
    /// <param name="children">The dimensional objects to include in the hull operation.</param>
    internal Hull(params IDimensionalObject<TUnit>[] children)
    {
        Children = children;
    }

    /// <inheritdoc />
    public override void WriteArgs(StringWriter w)
    {
        // no args
    }
}

/// <summary>
/// Extension methods for creating hull operations.
/// </summary>
public static class HullExtensions
{
    /// <summary>
    /// Creates a hull operation from a sequence of dimensional objects.
    /// </summary>
    /// <param name="objs">The dimensional objects to include in the hull operation.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Hull{TUnit}"/> instance representing the hull of the provided objects.</returns>
    public static IDimensionalObject<TUnit> Hull<TUnit>(this IEnumerable<IDimensionalObject<TUnit>> objs)
        where TUnit : IDimensionalUnit
    {
        return new Hull<TUnit>(objs.ToArray());
    }

    /// <summary>
    /// Creates a hull operation from two or more dimensional objects.
    /// </summary>
    /// <param name="obj1">The first dimensional object.</param>
    /// <param name="obj2">The second dimensional object.</param>
    /// <param name="others">Additional dimensional objects to include in the hull operation.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Hull{TUnit}"/> instance representing the hull of the provided objects.</returns>
    public static IDimensionalObject<TUnit> Hull<TUnit>(this IDimensionalObject<TUnit> obj1,
        IDimensionalObject<TUnit> obj2, params IDimensionalObject<TUnit>[] others)
        where TUnit : IDimensionalUnit
    {
        var all = new List<IDimensionalObject<TUnit>> { obj1, obj2 };
        all.AddRange(others);
        return new Hull<TUnit>(all.ToArray());
    }
}