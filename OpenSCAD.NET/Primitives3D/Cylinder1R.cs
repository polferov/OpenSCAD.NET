using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class Cylinder1R(Unit radius, Unit height, bool center = false, FragmentOptions fragmentOptions = default)
    : IDimensionalObject<Unit3D>, IHasFragmentOptions<Cylinder1R>
{
    public Unit Radius { get; } = radius;
    public Unit Height { get; } = height;

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cylinder(r={Radius}, h={Height}, center={center.ToLowerString()} {FragmentOptions});");
    }

    public static Cylinder1R FromRadiusAndHeight(Unit radius, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(radius, height, center, fragmentOptions);

    public static Cylinder1R FromDiameterAndHeight(Unit diameter, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(diameter / 2, height, center, fragmentOptions);

    public FragmentOptions FragmentOptions { get; } = fragmentOptions;

    public Cylinder1R WithFragmentOptions(FragmentOptions options)
    {
        return new Cylinder1R(Radius, Height, center, options);
    }
}