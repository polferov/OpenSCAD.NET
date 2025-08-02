using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Rotation(Angle3D angle, params I3DObject[] children) : ObjectWithChildren
{
    public override string Name => "rotate";
    public Angle3D Angle { get; } = angle;
    public override I3DObject[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        w.Write(Angle.ToString());
    }
}

public static class RotationExtensions
{
    public static I3DObject Rotate(this I3DObject obj, Angle3D amount)
    {
        return new Rotation(amount, obj);
    }

    public static I3DObject Rotate(this I3DObject obj, Angle x, Angle y, Angle z)
    {
        return new Rotation((x, y, z), obj);
    }

    public static I3DObject RotateX(this I3DObject obj, Angle amount)
    {
        return new Rotation((amount, 0, 0), obj);
    }

    public static I3DObject RotateY(this I3DObject obj, Angle amount)
    {
        return new Rotation((0, amount, 0), obj);
    }

    public static I3DObject RotateZ(this I3DObject obj, Angle amount)
    {
        return new Rotation((0, 0, amount), obj);
    }
}