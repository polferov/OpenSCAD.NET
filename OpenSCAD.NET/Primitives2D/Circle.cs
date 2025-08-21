using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

public class Circle : IDimensionalObject<Unit2D>, IHasFragmentOptions<Circle>
{
    public Unit Radius { get; }
    public Unit Diameter => Radius * 2;
    public FragmentOptions FragmentOptions { get; }

    private Circle(Unit radius, FragmentOptions fragmentOptions = default)
    {
        Radius = radius;
        FragmentOptions = fragmentOptions;
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

    public Circle WithFragmentOptions(FragmentOptions options)
    {
        return new Circle(Radius, options);
    }
}