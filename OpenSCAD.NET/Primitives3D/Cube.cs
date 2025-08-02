using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Cube(Unit3D dimensions, bool centered = false) : I3DObject
{
    public Unit3D Dimensions { get; } = dimensions;

    public Cube(Unit sideLength, bool centered = false)
        : this((sideLength, sideLength, sideLength), centered)
    {
    }

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cube({Dimensions}, centered = {centered});");
    }
}