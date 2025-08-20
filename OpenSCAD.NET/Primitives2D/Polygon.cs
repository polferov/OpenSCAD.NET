using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

public class Polygon : IDimensionalObject<Unit2D>
{
    public Unit2D[] Points { get; }

    private Polygon(Unit2D[] points)
    {
        Points = points;
    }
    
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.Write("polygon([");
        for (int i = 0; i < Points.Length-1; i++)
            w.Write($"{Points[i]}, ");
        w.WriteLine($"{Points[^1]}]);");
    }
    
    public static Polygon FromPoints(params Unit2D[] points)
    {
        if (points == null || points.Length < 3)
            throw new ArgumentException("A polygon must have at least 3 points.");

        return new Polygon(points);
    }
}