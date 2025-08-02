namespace OpenSCAD.NET.Primitives3D;

public class Cube(Unit x, Unit y, Unit z, bool centered = false) : I3DObject
{
    public Unit X { get; } = x;
    public Unit Y { get; } = y;
    public Unit Z { get; } = z;

    public Cube(Unit sideLength, bool centered = false)
        : this(sideLength, sideLength, sideLength, centered)
    {
    }

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cube([{X.Millimeters}, {Y.Millimeters}, {Z.Millimeters}], centered = {centered});");
    }
}