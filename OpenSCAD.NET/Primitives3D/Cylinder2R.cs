using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

/// <summary>
/// Represents a 3D cylinder primitive with two radii, configurable height, centering, and fragment options.
/// </summary>
public class Cylinder2R : IDimensionalObject<Unit3D>, IHasFragmentOptions<Cylinder2R>
{
    /// <summary>
    /// Indicates whether the cylinder is centered at the origin.
    /// </summary>
    private readonly bool _center;

    /// <summary>
    /// Initializes a new instance of the <see cref="Cylinder2R"/> class with the specified radii, height, centering, and fragment options.
    /// </summary>
    /// <param name="radius1">The radius of the bottom base of the cylinder.</param>
    /// <param name="radius2">The radius of the top base of the cylinder.</param>
    /// <param name="height">The height of the cylinder.</param>
    /// <param name="center">Whether the cylinder is centered at the origin.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the cylinder.</param>
    private Cylinder2R(Unit radius1, Unit radius2, Unit height, bool center, FragmentOptions fragmentOptions = default)
    {
        _center = center;
        Radius1 = radius1;
        Radius2 = radius2;
        Height = height;
        FragmentOptions = fragmentOptions;
    }

    /// <summary>
    /// Gets the radius of the bottom base of the cylinder.
    /// </summary>
    public Unit Radius1 { get; }

    /// <summary>
    /// Gets the radius of the top base of the cylinder.
    /// </summary>
    public Unit Radius2 { get; }

    /// <summary>
    /// Gets the height of the cylinder.
    /// </summary>
    public Unit Height { get; }

    /// <summary>
    /// Writes the OpenSCAD representation of the cylinder to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cylinder(r1={Radius1}, r2={Radius2}, h={Height}, center={_center.ToLowerString()} {FragmentOptions});");
    }

    /// <summary>
    /// Creates a new <see cref="Cylinder2R"/> instance from the specified radii and height.
    /// </summary>
    /// <param name="radius1">The radius of the bottom base of the cylinder.</param>
    /// <param name="radius2">The radius of the top base of the cylinder.</param>
    /// <param name="height">The height of the cylinder.</param>
    /// <param name="center">Whether the cylinder is centered at the origin.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the cylinder.</param>
    /// <returns>A new <see cref="Cylinder2R"/> instance.</returns>
    public static Cylinder2R FromRadiiAndHeight(Unit radius1, Unit radius2, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(radius1, radius2, height, center, fragmentOptions);

    /// <summary>
    /// Creates a new <see cref="Cylinder2R"/> instance from the specified diameters and height.
    /// </summary>
    /// <param name="diameter1">The diameter of the bottom base of the cylinder.</param>
    /// <param name="diameter2">The diameter of the top base of the cylinder.</param>
    /// <param name="height">The height of the cylinder.</param>
    /// <param name="center">Whether the cylinder is centered at the origin.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the cylinder.</param>
    /// <returns>A new <see cref="Cylinder2R"/> instance.</returns>
    public static Cylinder2R FromDiametersAndHeight(Unit diameter1, Unit diameter2, Unit height, bool center = false,
        FragmentOptions fragmentOptions = default)
        => new(diameter1 / 2, diameter2 / 2, height, center, fragmentOptions);

    /// <summary>
    /// Gets the fragment options for rendering the cylinder.
    /// </summary>
    public FragmentOptions FragmentOptions { get; }

    /// <summary>
    /// Returns a new <see cref="Cylinder2R"/> instance with the specified fragment options.
    /// </summary>
    /// <param name="options">The fragment options to apply.</param>
    /// <returns>A new <see cref="Cylinder2R"/> instance with the given fragment options.</returns>
    public Cylinder2R WithFragmentOptions(FragmentOptions options)
    {
        return new Cylinder2R(Radius1, Radius2, Height, _center, options);
    }
}