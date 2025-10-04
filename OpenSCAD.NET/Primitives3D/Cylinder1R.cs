using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

/// <summary>
/// Represents a 3D cylinder primitive with a single radius, configurable height, centering, and fragment options.
/// </summary>
public class Cylinder1R : IDimensionalObject<Unit3D>, IHasFragmentOptions<Cylinder1R>
{
    /// <summary>
    /// Indicates whether the cylinder is centered at the origin.
    /// </summary>
    private readonly bool _center;

    /// <summary>
    /// Initializes a new instance of the <see cref="Cylinder1R"/> class with the specified radius, height, centering, and fragment options.
    /// </summary>
    /// <param name="radius">The radius of the cylinder base.</param>
    /// <param name="height">The height of the cylinder.</param>
    /// <param name="center">Whether the cylinder is centered at the origin.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the cylinder.</param>
    private Cylinder1R(Unit radius, Unit height, bool center = false, FragmentOptions fragmentOptions = default)
    {
        _center = center;
        Radius = radius;
        Height = height;
        FragmentOptions = fragmentOptions;
    }

    /// <summary>
    /// Gets the radius of the cylinder base.
    /// </summary>
    public Unit Radius { get; }

    /// <summary>
    /// Gets the height of the cylinder.
    /// </summary>
    public Unit Height { get; }

    /// <summary>
    /// Gets the fragment options for rendering the cylinder.
    /// </summary>
    public FragmentOptions FragmentOptions { get; }

    /// <summary>
    /// Writes the OpenSCAD representation of the cylinder to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cylinder(r={Radius}, h={Height}, center={_center.ToLowerString()} {FragmentOptions});");
    }

    /// <summary>
    /// Creates a new <see cref="Cylinder1R"/> instance from the specified radius and height.
    /// </summary>
    /// <param name="radius">The radius of the cylinder base.</param>
    /// <param name="height">The height of the cylinder.</param>
    /// <param name="center">Whether the cylinder is centered at the origin.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the cylinder.</param>
    /// <returns>A new <see cref="Cylinder1R"/> instance.</returns>
    public static Cylinder1R FromRadiusAndHeight(Unit radius, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(radius, height, center, fragmentOptions);

    /// <summary>
    /// Creates a new <see cref="Cylinder1R"/> instance from the specified diameter and height.
    /// </summary>
    /// <param name="diameter">The diameter of the cylinder base.</param>
    /// <param name="height">The height of the cylinder.</param>
    /// <param name="center">Whether the cylinder is centered at the origin.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the cylinder.</param>
    /// <returns>A new <see cref="Cylinder1R"/> instance.</returns>
    public static Cylinder1R FromDiameterAndHeight(Unit diameter, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(diameter / 2, height, center, fragmentOptions);

    /// <summary>
    /// Returns a new <see cref="Cylinder1R"/> instance with the specified fragment options.
    /// </summary>
    /// <param name="options">The fragment options to apply.</param>
    /// <returns>A new <see cref="Cylinder1R"/> instance with the given fragment options.</returns>
    public Cylinder1R WithFragmentOptions(FragmentOptions options)
    {
        return new Cylinder1R(Radius, Height, _center, options);
    }
}