using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Cylinder2R(Unit radius1, Unit radius2, Unit height, bool center, FragmentOptions fragmentOptions = default)
    : IDimensionalObject<Unit3D>, IHasFragmentOptions<Cylinder2R>
{
    public Unit Radius1 { get; } = radius1;
    public Unit Radius2 { get; } = radius2;
    public Unit Height { get; } = height;

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cylinder(r1={Radius1}, r2={Radius2}, h={Height}, center={center.ToLowerString()} {FragmentOptions});");
    }

    public static Cylinder2R FromRadiiAndHeight(Unit radius1, Unit radius2, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(radius1, radius2, height, center);

    public static Cylinder2R FromDiametersAndHeight(Unit diameter1, Unit diameter2, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(diameter1 / 2, diameter2 / 2, height, center);

    public FragmentOptions FragmentOptions { get; } = fragmentOptions;

    public Cylinder2R WithFragmentOptions(FragmentOptions options)
    {
        return new Cylinder2R(Radius1, Radius2, Height, center, options);
    }
}