using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Boolean;

public class Difference<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    public override string Name => "difference";
    public override IDimensionalObject<TUnit>[] Children { get; }

    internal Difference(IDimensionalObject<TUnit> baseObject, params IDimensionalObject<TUnit>[] subtractedObjects)
    {
        if (subtractedObjects.Length == 0)
            throw new ArgumentException("At least one object must be provided to subtract from the base object.",
                nameof(subtractedObjects));
        Children = [baseObject, ..subtractedObjects];
    }

    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

public static class DifferenceExtensions
{
    public static IDimensionalObject<TUnit> Subtract<TUnit>(this IDimensionalObject<TUnit> baseObject,
        params IDimensionalObject<TUnit>[] subtractedObject)
        where TUnit : IDimensionalUnit
    {
        return new Difference<TUnit>(baseObject, subtractedObject);
    }
}