using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

/// <summary>
/// Represents a 2D circle primitive with configurable radius, diameter, and fragment options.
/// </summary>
public class Circle : IDimensionalObject<Unit2D>, IHasFragmentOptions<Circle>
{
    /// <summary>
    /// Gets the radius of the circle.
    /// </summary>
    public Unit Radius { get; }

    /// <summary>
    /// Gets the diameter of the circle.
    /// </summary>
    public Unit Diameter => Radius * 2;

    /// <summary>
    /// Gets the fragment options for rendering the circle.
    /// </summary>
    public FragmentOptions FragmentOptions { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class with the specified radius and fragment options.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="fragmentOptions">The fragment options for rendering the circle.</param>
    private Circle(Unit radius, FragmentOptions fragmentOptions = default)
    {
        Radius = radius;
        FragmentOptions = fragmentOptions;
    }

    /// <summary>
    /// Creates a new <see cref="Circle"/> instance from the specified radius.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <returns>A new <see cref="Circle"/> instance.</returns>
    public static Circle FromRadius(Unit radius)
    {
        return new Circle(radius);
    }

    /// <summary>
    /// Creates a new <see cref="Circle"/> instance from the specified diameter.
    /// </summary>
    /// <param name="diameter">The diameter of the circle.</param>
    /// <returns>A new <see cref="Circle"/> instance.</returns>
    public static Circle FromDiameter(Unit diameter)
    {
        return new Circle(diameter / 2);
    }

    /// <summary>
    /// Writes the OpenSCAD representation of the circle to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"circle(r={Radius} {FragmentOptions});");
    }

    /// <summary>
    /// Returns a new <see cref="Circle"/> instance with the specified fragment options.
    /// </summary>
    /// <param name="options">The fragment options to apply.</param>
    /// <returns>A new <see cref="Circle"/> instance with the given fragment options.</returns>
    public Circle WithFragmentOptions(FragmentOptions options)
    {
        return new Circle(Radius, options);
    }
}