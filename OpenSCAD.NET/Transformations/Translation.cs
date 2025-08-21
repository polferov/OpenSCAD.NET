using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Translation<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit

{
    internal Translation(Unit3D amount, params IDimensionalObject<TUnit>[] children)
    {
        Amount = amount;
        Children = children;
    }

    public Unit3D Amount { get; }
    public override IDimensionalObject<TUnit>[] Children { get; }
    public override string Name => "translate";

    public override void WriteArgs(StringWriter w)
    {
        w.Write(Amount.ToString());
    }
}

public static class TranslationExtensions
{
    public static IDimensionalObject<TUnit> Translate<TUnit>(this IDimensionalObject<TUnit> obj, Unit3D amount)
        where TUnit : IDimensionalUnit
    {
        return new Translation<TUnit>(amount, obj);
    }

    public static IDimensionalObject<TUnit> Translate<TUnit>(this IDimensionalObject<TUnit> obj, Unit x, Unit y, Unit z)
        where TUnit : IDimensionalUnit
    {
        return new Translation<TUnit>((x, y, z), obj);
    }

    public static IDimensionalObject<TUnit> TranslateX<TUnit>(this IDimensionalObject<TUnit> obj, Unit amount)
        where TUnit : IDimensionalUnit
    {
        return new Translation<TUnit>((amount, 0, 0), obj);
    }

    public static IDimensionalObject<TUnit> TranslateY<TUnit>(this IDimensionalObject<TUnit> obj, Unit amount)
        where TUnit : IDimensionalUnit
    {
        return new Translation<TUnit>((0, amount, 0), obj);
    }

    public static IDimensionalObject<TUnit> TranslateZ<TUnit>(this IDimensionalObject<TUnit> obj, Unit amount)
        where TUnit : IDimensionalUnit
    {
        return new Translation<TUnit>((0, 0, amount), obj);
    }
}