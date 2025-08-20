using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Scale<TUnit>(TUnit scale, params IDimensionalObject<TUnit>[] children)
    : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    public TUnit ScaleDimensions { get; } = scale;
    public override string Name => "scale";
    public override IDimensionalObject<TUnit>[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        w.Write(ScaleDimensions.ToString());
    }
}

public static class ScaleExtensions
{
    public static IDimensionalObject<TUnit> Scale<TUnit>(this IDimensionalObject<TUnit> obj, TUnit scale) 
        where TUnit : IDimensionalUnit
    {
        return new Scale<TUnit>(scale, obj);
    }

    public static IDimensionalObject<Unit3D> Scale(this IDimensionalObject<Unit3D> obj, Unit x, Unit y, Unit z)
    {
        return new Scale<Unit3D>((x, y, z), obj);
    }

    public static IDimensionalObject<Unit3D> ScaleX(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Scale<Unit3D>((amount, 1, 1), obj);
    }

    public static IDimensionalObject<Unit3D> ScaleY(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Scale<Unit3D>((1, amount, 1), obj);
    }

    public static IDimensionalObject<Unit3D> ScaleZ(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Scale<Unit3D>((1, 1, amount), obj);
    }

    public static IDimensionalObject<Unit2D> Scale(this IDimensionalObject<Unit2D> obj, Unit2D scale)
    {
        return new Scale<Unit2D>(scale, obj);
    }

    public static IDimensionalObject<Unit2D> Scale(this IDimensionalObject<Unit2D> obj, Unit x, Unit y)
    {
        return new Scale<Unit2D>((x, y), obj);
    }

    public static IDimensionalObject<Unit2D> ScaleX(this IDimensionalObject<Unit2D> obj, Unit amount)
    {
        return new Scale<Unit2D>((amount, 1), obj);
    }

    public static IDimensionalObject<Unit2D> ScaleY(this IDimensionalObject<Unit2D> obj, Unit amount)
    {
        return new Scale<Unit2D>((1, amount), obj);
    }
}