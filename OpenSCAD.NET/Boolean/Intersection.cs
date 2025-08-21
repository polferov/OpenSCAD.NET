using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Boolean;

public class Intersection<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    internal Intersection(params IDimensionalObject<TUnit>[] children)
    {
        Children = children;
    }

    public override string Name => "intersection";
    public override IDimensionalObject<TUnit>[] Children { get; }

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
    
    public static IDimensionalObject<TUnit> Intersect<TUnit>(this IDimensionalObject<TUnit> object1,
        IDimensionalObject<TUnit> object2)
        where TUnit : IDimensionalUnit
    {
        return new Intersection<TUnit>(object1, object2);
    }
}