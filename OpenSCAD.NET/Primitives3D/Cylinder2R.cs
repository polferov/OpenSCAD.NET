using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Cylinder2R(Unit radius1, Unit radius2, Unit height, bool center) : IDimensionalObject<Unit3D>
{
    public Unit Radius1 { get; } = radius1;
    public Unit Radius2 { get; } = radius2;
    public Unit Height { get; } = height;

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cylinder(r1={Radius1}, r2={Radius2}, h={Height}, center={center.ToLowerString()});");
    }

    public static Cylinder2R FromRadiiAndHeight(Unit radius1, Unit radius2, Unit height, bool center = false)
        => new(radius1, radius2, height, center);

    public static Cylinder2R FromDiametersAndHeight(Unit diameter1, Unit diameter2, Unit height, bool center = false)
        => new(diameter1 / 2, diameter2 / 2, height, center);
}