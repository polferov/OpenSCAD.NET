using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives2D;

public class PolygonBuilder
{
    public Unit2D Point { get; }
    public PolygonBuilder? Previous { get; }

    private PolygonBuilder(Unit2D point, PolygonBuilder? previous)
    {
        Point = point;
        Previous = previous;
    }

    public static PolygonBuilder FromPoint(Unit2D point)
    {
        return new PolygonBuilder(point, null);
    }

    public PolygonBuilder AddPoint(Unit2D point)
    {
        return new PolygonBuilder(point, this);
    }

    public PolygonBuilder ThenMove(Unit2D offset)
    {
        return AddPoint(Point + offset);
    }


    public PolygonBuilder ThenMove(Unit offsetX, Unit offsetY)
    {
        return AddPoint(Point + (offsetX, offsetY));
    }

    public PolygonBuilder ThenMoveX(Unit offset)
    {
        return ThenMove(offset, 0);
    }

    public PolygonBuilder ThenMoveY(Unit offset)
    {
        return ThenMove(0, offset);
    }

    public Polygon Build()
    {
        var points = new List<Unit2D>();
        var current = this;
        while (current != null)
        {
            points.Add(current.Point);
            current = current.Previous;
        }

        points.Reverse();
        return Polygon.FromPoints(points.ToArray());
    }
}