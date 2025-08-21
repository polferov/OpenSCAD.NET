using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

public class Square : IDimensionalObject<Unit2D>
{
    private Square(Unit2D dimensions)
    {
        Dimensions = dimensions;
    }

    public Unit2D Dimensions { get; }

    public static Square FromSideLength(Unit sideLength)
        => new((sideLength, sideLength));

    public static Square FromDimensions(Unit2D dimensions)
        => new(dimensions);

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"square({Dimensions});");
    }
}