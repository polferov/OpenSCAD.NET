using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Minkowski<TUnit>(params IDimensionalObject<TUnit>[] children) : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit

{
    public override string Name => "minkowski";
    public override IDimensionalObject<TUnit>[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        // noop
    }
}

public static class MinkowskiExtensions
{
    public static IDimensionalObject<TUnit> Minkowski<TUnit>(this IDimensionalObject<TUnit> obj,
        params IDimensionalObject<TUnit>[] others) where TUnit : IDimensionalUnit
    {
        return new Minkowski<TUnit>(new[] { obj }.Concat(others).ToArray());
    }
}