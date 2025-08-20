using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Translation<TChild>(Unit3D amount, params TChild[] children) : ObjectWithChildren<TChild>, I3DObject, I2DObject
    where TChild : IDimensionalObject
{
    public Unit3D Amount { get; } = amount;
    public override TChild[] Children { get; } = children;
    public override string Name => "translate";

    public override void WriteArgs(StringWriter w)
    {
        w.Write(Amount.ToString());
    }
}

public static class TranslationExtensions
{
    public static I3DObject Translate(this I3DObject obj, Unit3D amount)
    {
        return new Translation<I3DObject>(amount, obj);
    }

    public static I3DObject Translate(this I3DObject obj, Unit x, Unit y, Unit z)
    {
        return new Translation<I3DObject>((x, y, z), obj);
    }

    public static I3DObject TranslateX(this I3DObject obj, Unit amount)
    {
        return new Translation<I3DObject>((amount, 0, 0), obj);
    }

    public static I3DObject TranslateY(this I3DObject obj, Unit amount)
    {
        return new Translation<I3DObject>((0, amount, 0), obj);
    }

    public static I3DObject TranslateZ(this I3DObject obj, Unit amount)
    {
        return new Translation<I3DObject>((0, 0, amount), obj);
    }
}