using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Boolean;

public class Union<TUnit>(params IDimensionalObject<TUnit>[] children) : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    public override string Name => "union";
    public override IDimensionalObject<TUnit>[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

public static class UnionExtensions
{
    public static IDimensionalObject<TUnit> Union<TUnit>(this IDimensionalObject<TUnit>[] objects)
        where TUnit : IDimensionalUnit
    {
        return new Union<TUnit>(objects);
    }
}