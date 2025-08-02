using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Cube : I3DObject
{
    private readonly bool _centered;
    public Unit3D Dimensions { get; }


    private Cube(Unit3D dimensions, bool centered = false)
    {
        _centered = centered;
        Dimensions = dimensions;
    }

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cube({Dimensions}, centered = {_centered});");
    }

    public static Cube WithDimensions(Unit3D dimensions, bool centered = false)
    {
        return new Cube(dimensions, centered);
    }

    public static Cube WithSideLength(Unit sideLength, bool centered = false)
    {
        return new Cube((sideLength, sideLength, sideLength), centered);
    }
}