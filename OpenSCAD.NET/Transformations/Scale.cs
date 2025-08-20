using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Scale3D<TChild>(Unit3D scale, params TChild[] children)
    : ObjectWithChildren<TChild>, I3DObject, I2DObject
    where TChild : IDimensionalObject
{
    public Unit3D ScaleDimensions { get; } = scale;
    public override string Name => "scale";
    public override TChild[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        w.Write(ScaleDimensions.ToString());
    }
}

public class Scale2D<TChild>(Unit2D scale, params TChild[] children)
    : ObjectWithChildren<TChild>, I3DObject, I2DObject
    where TChild : IDimensionalObject
{
    public Unit2D ScaleDimensions { get; } = scale;
    public override string Name => "scale";
    public override TChild[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        w.Write(ScaleDimensions.ToString());
    }
}

public static class ScaleExtensions
{
    public static I3DObject Scale(this I3DObject obj, Unit3D scale)
    {
        return new Scale3D<I3DObject>(scale, obj);
    }

    public static I3DObject Scale(this I3DObject obj, Unit x, Unit y, Unit z)
    {
        return new Scale3D<I3DObject>((x, y, z), obj);
    }

    public static I3DObject ScaleX(this I3DObject obj, Unit amount)
    {
        return new Scale3D<I3DObject>((amount, 1, 1), obj);
    }

    public static I3DObject ScaleY(this I3DObject obj, Unit amount)
    {
        return new Scale3D<I3DObject>((1, amount, 1), obj);
    }

    public static I3DObject ScaleZ(this I3DObject obj, Unit amount)
    {
        return new Scale3D<I3DObject>((1, 1, amount), obj);
    }

    public static I2DObject Scale(this I2DObject obj, Unit2D scale)
    {
        return new Scale2D<I2DObject>(scale, obj);
    }

    public static I2DObject Scale(this I2DObject obj, Unit x, Unit y)
    {
        return new Scale2D<I2DObject>((x, y), obj);
    }

    public static I2DObject ScaleX(this I2DObject obj, Unit amount)
    {
        return new Scale2D<I2DObject>((amount, 1), obj);
    }

    public static I2DObject ScaleY(this I2DObject obj, Unit amount)
    {
        return new Scale2D<I2DObject>((1, amount), obj);
    }
}