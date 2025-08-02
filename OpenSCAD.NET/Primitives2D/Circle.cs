using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

public class Circle
{
    public Unit Radius { get; }
    public Unit Diameter => Radius * 2;

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
}