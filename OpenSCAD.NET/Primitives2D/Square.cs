using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

public class Square
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
}