using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

/// <summary>
/// Represents a 2D square primitive with configurable dimensions.
/// </summary>
public class Square : IDimensionalObject<Unit2D>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Square"/> class with the specified dimensions.
    /// </summary>
    /// <param name="dimensions">The dimensions of the square.</param>
    private Square(Unit2D dimensions)
    {
        Dimensions = dimensions;
    }

    /// <summary>
    /// Gets the dimensions of the square.
    /// </summary>
    public Unit2D Dimensions { get; }

    /// <summary>
    /// Creates a new <see cref="Square"/> instance with equal side lengths.
    /// </summary>
    /// <param name="sideLength">The length of each side of the square.</param>
    /// <returns>A new <see cref="Square"/> instance.</returns>
    public static Square FromSideLength(Unit sideLength)
        => new((sideLength, sideLength));

    /// <summary>
    /// Creates a new <see cref="Square"/> instance with the specified dimensions.
    /// </summary>
    /// <param name="dimensions">The dimensions of the square.</param>
    /// <returns>A new <see cref="Square"/> instance.</returns>
    public static Square FromDimensions(Unit2D dimensions)
        => new(dimensions);

    /// <summary>
    /// Writes the OpenSCAD representation of the square to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"square({Dimensions});");
    }
}