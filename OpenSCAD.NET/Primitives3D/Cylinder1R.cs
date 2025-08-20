using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Cylinder1R(Unit radius, Unit height, bool center = false) : IDimensionalObject<Unit3D>
{
    public Unit Radius { get; } = radius;
    public Unit Height { get; } = height;

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cylinder(r={Radius}, h={Height}, center={center.ToLowerString()});");
    }

    public static Cylinder1R FromRadiusAndHeight(Unit radius, Unit height, bool center = false)
        => new(radius, height, center);

    public static Cylinder1R FromDiameterAndHeight(Unit diameter, Unit height, bool center = false)
        => new(diameter / 2, height, center);
}