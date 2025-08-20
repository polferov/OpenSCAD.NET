using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

public class Circle : I2DObject, IHasFragmentOptions
{
    public Unit Radius { get; }
    public Unit Diameter => Radius * 2;
    public FragmentOptions FragmentOptions { get; set; }

    private Circle(Unit radius)
    {
        Radius = radius;
    }

    public static Circle FromRadius(Unit radius)
    {
        return new Circle(radius);
    }

    public static Circle FromDiameter(Unit diameter)
    {
        return new Circle(diameter / 2);
    }

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"circle(r={Radius} {FragmentOptions});");
    }

}