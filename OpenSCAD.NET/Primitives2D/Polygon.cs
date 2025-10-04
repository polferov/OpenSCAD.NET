using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

/// <summary>
/// Represents a 2D polygon primitive defined by a sequence of points.
/// </summary>
public class Polygon : IDimensionalObject<Unit2D>
{
    /// <summary>
    /// Gets the points that define the vertices of the polygon.
    /// </summary>
    public Unit2D[] Points { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Polygon"/> class with the specified points.
    /// </summary>
    /// <param name="points">The array of points that define the polygon.</param>
    private Polygon(Unit2D[] points)
    {
        Points = points;
    }
    
    /// <summary>
    /// Writes the OpenSCAD representation of the polygon to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.Write("polygon([");
        for (int i = 0; i < Points.Length-1; i++)
            w.Write($"{Points[i]}, ");
        w.WriteLine($"{Points[^1]}]);");
    }
    
    /// <summary>
    /// Creates a new <see cref="Polygon"/> instance from the specified points.
    /// </summary>
    /// <param name="points">The array of points that define the polygon. Must contain at least 3 points.</param>
    /// <returns>A new <see cref="Polygon"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown if fewer than 3 points are provided.</exception>
    public static Polygon FromPoints(params Unit2D[] points)
    {
        if (points == null || points.Length < 3)
            throw new ArgumentException("A polygon must have at least 3 points.");

        return new Polygon(points);
    }
}