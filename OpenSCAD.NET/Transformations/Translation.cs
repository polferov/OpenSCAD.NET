using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Translation<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit

{
    internal Translation(TUnit amount, params IDimensionalObject<TUnit>[] children)
    {
        Amount = amount;
        Children = children;
    }

    public TUnit Amount { get; }
    public override IDimensionalObject<TUnit>[] Children { get; }
    public override string Name => "translate";

    public override void WriteArgs(StringWriter w)
    {
        w.Write(Amount.ToString());
    }
}

public static class TranslationExtensions
{
    public static IDimensionalObject<TUnit> Translate<TUnit>(this IDimensionalObject<TUnit> obj, TUnit amount)
        where TUnit : IDimensionalUnit
    {
        return new Translation<TUnit>(amount, obj);
    }

    public static IDimensionalObject<Unit3D> Translate(this IDimensionalObject<Unit3D> obj, Unit x, Unit y, Unit z)
    {
        return new Translation<Unit3D>((x, y, z), obj);
    }

    public static IDimensionalObject<Unit2D> Translate(this IDimensionalObject<Unit2D> obj, Unit x, Unit y)
    {
        return new Translation<Unit2D>((x, y), obj);
    }

    public static IDimensionalObject<Unit3D> TranslateX(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Translation<Unit3D>((amount, 0, 0), obj);
    }

    public static IDimensionalObject<Unit2D> TranslateX(this IDimensionalObject<Unit2D> obj, Unit amount)
    {
        return new Translation<Unit2D>((amount, 0), obj);
    }

    public static IDimensionalObject<Unit3D> TranslateY(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Translation<Unit3D>((0, amount, 0), obj);
    }

    public static IDimensionalObject<Unit2D> TranslateY(this IDimensionalObject<Unit2D> obj, Unit amount)
    {
        return new Translation<Unit2D>((0, amount), obj);
    }

    public static IDimensionalObject<Unit3D> TranslateZ(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Translation<Unit3D>((0, 0, amount), obj);
    }
}