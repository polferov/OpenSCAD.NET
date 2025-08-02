using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Boolean;

public class Difference : ObjectWithChildren
{
    public override string Name => "difference";
    public override I3DObject[] Children { get; }

    public Difference(I3DObject baseObject, params I3DObject[] subtractedObjects)
    {
        if (subtractedObjects.Length == 0)
            throw new ArgumentException("At least one object must be provided to subtract from the base object.",
                nameof(subtractedObjects));
        Children = [baseObject, ..subtractedObjects];
    }

    public override void WriteArgs(StringWriter w)
    {
        // no op
    }
}

public static class DifferenceExtensions
{
    public static I3DObject Subtract(this I3DObject baseObject, params I3DObject[] subtractedObject)
    {
        return new Difference(baseObject, subtractedObject);
    }
}