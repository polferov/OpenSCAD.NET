using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

/// <summary>
/// Represents a 3D cube primitive with configurable dimensions and centering option.
/// </summary>
public class Cube : IDimensionalObject<Unit3D>
{
    /// <summary>
    /// Indicates whether the cube is centered at the origin.
    /// </summary>
    private readonly bool _center;

    /// <summary>
    /// Gets the dimensions of the cube.
    /// </summary>
    public Unit3D Dimensions { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="Cube"/> class with the specified dimensions and centering option.
    /// </summary>
    /// <param name="dimensions">The dimensions of the cube.</param>
    /// <param name="center">Whether the cube is centered at the origin.</param>
    private Cube(Unit3D dimensions, bool center = false)
    {
        _center = center;
        Dimensions = dimensions;
    }

    /// <summary>
    /// Writes the OpenSCAD representation of the cube to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"cube({Dimensions}, center = {_center.ToLowerString()});");
    }

    /// <summary>
    /// Creates a new <see cref="Cube"/> instance with the specified dimensions and centering option.
    /// </summary>
    /// <param name="dimensions">The dimensions of the cube.</param>
    /// <param name="center">Whether the cube is centered at the origin.</param>
    /// <returns>A new <see cref="Cube"/> instance.</returns>
    public static Cube FromDimensions(Unit3D dimensions, bool center = false)
    {
        return new Cube(dimensions, center);
    }

    /// <summary>
    /// Creates a new <see cref="Cube"/> instance with equal side lengths and centering option.
    /// </summary>
    /// <param name="sideLength">The length of each side of the cube.</param>
    /// <param name="center">Whether the cube is centered at the origin.</param>
    /// <returns>A new <see cref="Cube"/> instance.</returns>
    public static Cube FromSideLength(Unit sideLength, bool center = false)
    {
        return new Cube((sideLength, sideLength, sideLength), center);
    }
}