using OpenSCAD.NET.Primitives2D;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Extended2D;

public class PolygonBuilder
{
    private readonly List<Unit2D> _points;
    public Unit2D Point => _points.LastOrDefault(new Unit2D(0, 0));

    private PolygonBuilder(List<Unit2D> points)
    {
        _points = points;
    }

    public static PolygonBuilder FromPoint(Unit2D point)
    {
        return new PolygonBuilder([point]);
    }

    public PolygonBuilder AddPoint(Unit2D point)
    {
        _points.Add(point);
        return this;
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
        if (_points.Count < 3)
            throw new InvalidOperationException("A polygon must have at least 3 points.");

        return Polygon.FromPoints(_points.ToArray());
    }
}