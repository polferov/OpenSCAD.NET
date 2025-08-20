using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Boolean;

public class Union(params I3DObject[] children) : ObjectWithChildren<I3DObject>, I3DObject
{
    public override string Name => "union";
    public override I3DObject[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

public static class UnionExtensions
{
    public static I3DObject Union(this I3DObject[] objects)
    {
        return new Union(objects);
    }

    public static I3DObject Union(this I3DObject obj, params I3DObject[] otherObjects)
    {
        return new Union([obj, ..otherObjects]);
    }
}