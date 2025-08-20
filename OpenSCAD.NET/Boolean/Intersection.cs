using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Boolean;

public class Intersection<TUnit>(params IDimensionalObject<TUnit>[] children) : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    public override string Name => "intersection";
    public override IDimensionalObject<TUnit>[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

public static class IntersectionExtensions
{
    public static IDimensionalObject<TUnit> Intersect<TUnit>(this IDimensionalObject<TUnit>[] objects)
        where TUnit : IDimensionalUnit
    {
        return new Intersection<TUnit>(objects);
    }
}