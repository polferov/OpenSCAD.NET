using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Rotation<TUnit>(Angle3D angle, params IDimensionalObject<TUnit>[] children)
    : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    public override string Name => "rotate";
    public Angle3D Angle { get; } = angle;
    public override IDimensionalObject<TUnit>[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        w.Write(Angle.ToString());
    }
}

public static class RotationExtensions
{
    public static IDimensionalObject<TUnit> Rotate<TUnit>(this IDimensionalObject<TUnit> obj, Angle3D amount)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>(amount, obj);
    }

    public static IDimensionalObject<TUnit> Rotate<TUnit>(this IDimensionalObject<TUnit> obj, Angle x, Angle y, Angle z)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>((x, y, z), obj);
    }

    public static IDimensionalObject<TUnit> RotateX<TUnit>(this IDimensionalObject<TUnit> obj, Angle amount)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>((amount, 0, 0), obj);
    }

    public static IDimensionalObject<TUnit> RotateY<TUnit>(this IDimensionalObject<TUnit> obj, Angle amount)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>((0, amount, 0), obj);
    }

    public static IDimensionalObject<TUnit> RotateZ<TUnit>(this IDimensionalObject<TUnit> obj, Angle amount)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>((0, 0, amount), obj);
    }
}