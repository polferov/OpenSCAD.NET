using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Transformations;

public class Minkowski<TChild>(params TChild[] children) : ObjectWithChildren<TChild>, I3DObject, I2DObject
    where TChild : IDimensionalObject
{
    public override string Name => "minkowski";
    public override TChild[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        // noop
    }
}

public static class MinkowskiExtensions
{
    public static I3DObject Minkowski(this I3DObject obj, params I3DObject[] others)
    {
        return new Minkowski<I3DObject>(new[] { obj }.Concat(others).ToArray());
    }

    public static I2DObject Minkowski(this I2DObject obj, params I2DObject[] others)
    {
        return new Minkowski<I2DObject>(new[] { obj }.Concat(others).ToArray());
    }
}