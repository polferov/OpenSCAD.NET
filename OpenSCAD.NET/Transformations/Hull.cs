using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Hull<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    public override string Name => "hull";

    internal Hull(params IDimensionalObject<TUnit>[] children)
    {
        Children = children;
    }

    public override IDimensionalObject<TUnit>[] Children { get; }

    public override void WriteArgs(StringWriter w)
    {
        // no args
    }
}

public static class HullExtensions
{
    public static IDimensionalObject<TUnit> Hull<TUnit>(this IEnumerable<IDimensionalObject<TUnit>> objs)
        where TUnit : IDimensionalUnit
    {
        return new Hull<TUnit>(objs.ToArray());
    }

    public static IDimensionalObject<TUnit> Hull<TUnit>(this IDimensionalObject<TUnit> obj1,
        IDimensionalObject<TUnit> obj2, params IDimensionalObject<TUnit>[] others)
        where TUnit : IDimensionalUnit
    {
        var all = new List<IDimensionalObject<TUnit>> { obj1, obj2 };
        all.AddRange(others);
        return new Hull<TUnit>(all.ToArray());
    }
}