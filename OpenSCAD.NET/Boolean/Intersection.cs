using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Boolean;

public class Intersection(params I3DObject[] children) : ObjectWithChildren
{
    public override string Name => "intersection";
    public override I3DObject[] Children { get; } = children;

    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

public static class IntersectionExtensions
{
    public static I3DObject Intersect(this I3DObject[] objects)
    {
        return new Intersection(objects);
    }

    public static I3DObject Intersect(this I3DObject obj, params I3DObject[] otherObjects)
    {
        return new Intersection([obj, ..otherObjects]);
    }
}