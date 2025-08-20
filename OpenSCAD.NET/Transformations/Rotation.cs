using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Rotation<TChild>(Angle3D angle, params TChild[] children)
    : ObjectWithChildren<TChild>, I3DObject, I2DObject
    where TChild : IDimensionalObject
{
    public override string Name => "rotate";
    public Angle3D Angle { get; } = angle;
    public override TChild[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        w.Write(Angle.ToString());
    }
}

public static class RotationExtensions
{
    // 3d
    public static I3DObject Rotate(this I3DObject obj, Angle3D amount)
    {
        return new Rotation<I3DObject>(amount, obj);
    }

    public static I3DObject Rotate(this I3DObject obj, Angle x, Angle y, Angle z)
    {
        return new Rotation<I3DObject>((x, y, z), obj);
    }

    public static I3DObject RotateX(this I3DObject obj, Angle amount)
    {
        return new Rotation<I3DObject>((amount, 0, 0), obj);
    }

    public static I3DObject RotateY(this I3DObject obj, Angle amount)
    {
        return new Rotation<I3DObject>((0, amount, 0), obj);
    }

    public static I3DObject RotateZ(this I3DObject obj, Angle amount)
    {
        return new Rotation<I3DObject>((0, 0, amount), obj);
    }
    
    // 2d
    
    public static I2DObject Rotate(this I2DObject obj, Angle3D amount)
    {
        return new Rotation<I2DObject>(amount, obj);
    }

    public static I2DObject Rotate(this I2DObject obj, Angle x, Angle y, Angle z)
    {
        return new Rotation<I2DObject>((x, y, z), obj);
    }

    public static I2DObject RotateX(this I2DObject obj, Angle amount)
    {
        return new Rotation<I2DObject>((amount, 0, 0), obj);
    }

    public static I2DObject RotateY(this I2DObject obj, Angle amount)
    {
        return new Rotation<I2DObject>((0, amount, 0), obj);
    }

    public static I2DObject RotateZ(this I2DObject obj, Angle amount)
    {
        return new Rotation<I2DObject>((0, 0, amount), obj);
    }
}