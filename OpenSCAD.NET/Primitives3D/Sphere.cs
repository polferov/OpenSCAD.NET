using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

/// <summary>
/// Represents a 3D sphere primitive with configurable radius, diameter, and fragment options.
/// </summary>
public class Sphere : IDimensionalObject<Unit3D>, IHasFragmentOptions<Sphere>
{
    /// <summary>
    /// The radius of the sphere.
    /// </summary>
    private readonly Unit _radius;

    /// <summary>
    /// Initializes a new instance of the <see cref="Sphere"/> class with the specified radius and fragment options.
    /// </summary>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the sphere.</param>
    private Sphere(Unit radius, FragmentOptions fragmentOptions = default)
    {
        _radius = radius;
        FragmentOptions = fragmentOptions;
    }

    /// <summary>
    /// Writes the OpenSCAD representation of the sphere to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"sphere(r={_radius} {FragmentOptions});");
    }

    /// <summary>
    /// Creates a new <see cref="Sphere"/> instance from the specified radius.
    /// </summary>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the sphere.</param>
    /// <returns>A new <see cref="Sphere"/> instance.</returns>
    public static Sphere FromRadius(Unit radius, FragmentOptions fragmentOptions = default)
        => new(radius, fragmentOptions);

    /// <summary>
    /// Creates a new <see cref="Sphere"/> instance from the specified diameter.
    /// </summary>
    /// <param name="diameter">The diameter of the sphere.</param>
    /// <param name="fragmentOptions">Fragment options for rendering the sphere.</param>
    /// <returns>A new <see cref="Sphere"/> instance.</returns>
    public static Sphere FromDiameter(Unit diameter, FragmentOptions fragmentOptions = default)
        => new(diameter / 2, fragmentOptions);

    /// <summary>
    /// Gets the fragment options for rendering the sphere.
    /// </summary>
    public FragmentOptions FragmentOptions { get; }

    /// <summary>
    /// Returns a new <see cref="Sphere"/> instance with the specified fragment options.
    /// </summary>
    /// <param name="options">The fragment options to apply.</param>
    /// <returns>A new <see cref="Sphere"/> instance with the given fragment options.</returns>
    public Sphere WithFragmentOptions(FragmentOptions options)
    {
        return new Sphere(_radius, options);
    }
}