using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

public class Translation(Unit3D amount, params I3DObject[] children) : ObjectWithChildren
{
    public Unit3D Amount { get; } = amount;
    public override I3DObject[] Children { get; } = children;
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
        return new Translation(amount, obj);
    }

    public static I3DObject Translate(this I3DObject obj, Unit x, Unit y, Unit z)
    {
        return new Translation((x, y, z), obj);
    }

    public static I3DObject TranslateX(this I3DObject obj, Unit amount)
    {
        return new Translation((amount, 0, 0), obj);
    }

    public static I3DObject TranslateY(this I3DObject obj, Unit amount)
    {
        return new Translation((0, amount, 0), obj);
    }

    public static I3DObject TranslateZ(this I3DObject obj, Unit amount)
    {
        return new Translation((0, 0, amount), obj);
    }
}