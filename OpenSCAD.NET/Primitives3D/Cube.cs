using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Cube : I3DObject
{
    private readonly bool _center;
    public Unit3D Dimensions { get; }


    private Cube(Unit3D dimensions, bool center = false)
    {
        _center = center;
        Dimensions = dimensions;
    }

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cube({Dimensions}, center = {_center.ToLowerString()});");
    }

    public static Cube FromDimensions(Unit3D dimensions, bool center = false)
    {
        return new Cube(dimensions, center);
    }

    public static Cube FromSideLength(Unit sideLength, bool center = false)
    {
        return new Cube((sideLength, sideLength, sideLength), center);
    }
}