using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Sphere : IDimensionalObject<Unit3D>, IHasFragmentOptions<Sphere>
{
    private readonly Unit _radius;

    private Sphere(Unit radius, FragmentOptions fragmentOptions = default)
    {
        _radius = radius;
        FragmentOptions = fragmentOptions;
    }

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"sphere(r={_radius} {FragmentOptions});");
    }

    public static Sphere FromRadius(Unit radius, FragmentOptions fragmentOptions = default)
        => new(radius, fragmentOptions);

    public static Sphere FromDiameter(Unit diameter, FragmentOptions fragmentOptions = default)
        => new(diameter / 2, fragmentOptions);

    public FragmentOptions FragmentOptions { get; }

    public Sphere WithFragmentOptions(FragmentOptions options)
    {
        return new Sphere(_radius, options);
    }
}