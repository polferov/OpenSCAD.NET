using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Sphere(Unit radius) : I3DObject
{
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"sphere(r={radius});");
    }

    public static Sphere FromRadius(Unit radius)
        => new(radius);

    public static Sphere FromDiameter(Unit diameter)
        => new(diameter / 2);
}