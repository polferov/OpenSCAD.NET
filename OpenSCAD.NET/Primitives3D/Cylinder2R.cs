using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Cylinder2R : IDimensionalObject<Unit3D>, IHasFragmentOptions<Cylinder2R>
{
    private readonly bool _center;

    private Cylinder2R(Unit radius1, Unit radius2, Unit height, bool center, FragmentOptions fragmentOptions = default)
    {
        _center = center;
        Radius1 = radius1;
        Radius2 = radius2;
        Height = height;
        FragmentOptions = fragmentOptions;
    }

    public Unit Radius1 { get; }
    public Unit Radius2 { get; }
    public Unit Height { get; }

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cylinder(r1={Radius1}, r2={Radius2}, h={Height}, center={_center.ToLowerString()} {FragmentOptions});");
    }

    public static Cylinder2R FromRadiiAndHeight(Unit radius1, Unit radius2, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(radius1, radius2, height, center);

    public static Cylinder2R FromDiametersAndHeight(Unit diameter1, Unit diameter2, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(diameter1 / 2, diameter2 / 2, height, center);

    public FragmentOptions FragmentOptions { get; }

    public Cylinder2R WithFragmentOptions(FragmentOptions options)
    {
        return new Cylinder2R(Radius1, Radius2, Height, _center, options);
    }
}