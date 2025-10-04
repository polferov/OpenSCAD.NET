using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Boolean;

/// <summary>
/// Represents a boolean difference operation between dimensional objects.
/// </summary>
public class Difference<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <inheritdoc />
    public override string Name => "difference";

    /// <inheritdoc />
    public override IDimensionalObject<TUnit>[] Children { get; }

    internal Difference(IDimensionalObject<TUnit> baseObject, params IDimensionalObject<TUnit>[] subtractedObjects)
    {
        if (subtractedObjects.Length == 0)
            throw new ArgumentException("At least one object must be provided to subtract from the base object.",
                nameof(subtractedObjects));
        Children = [baseObject, ..subtractedObjects];
    }

    /// <inheritdoc />
    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

/// <summary>
/// Extension methods for creating difference operations.
/// </summary>
public static class DifferenceExtensions
{
    /// <summary>
    /// Creates a boolean difference operation between dimensional objects.
    /// </summary>
    /// <param name="baseObject">Object from which to subtract</param>
    /// <param name="subtractedObject">objects to be subtracted from <paramref name="baseObject"/></param>
    /// <returns>New instance of <see cref="Difference{TUnit}"/> representing the desired difference operation</returns>
    public static IDimensionalObject<TUnit> Subtract<TUnit>(this IDimensionalObject<TUnit> baseObject,
        params IDimensionalObject<TUnit>[] subtractedObject)
        where TUnit : IDimensionalUnit
    {
        return new Difference<TUnit>(baseObject, subtractedObject);
    }
}