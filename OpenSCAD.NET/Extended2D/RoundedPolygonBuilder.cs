using OpenSCAD.NET.Primitives2D;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Extended2D;

public class RoundedPolygonBuilder
{
    private readonly List<Unit2D> _points = [];
    private readonly List<Unit> _radii = [];

    private RoundedPolygonBuilder()
    {
    }

    public static RoundedPolygonBuilder New()
        => new RoundedPolygonBuilder();

    public RoundedPolygonBuilder AddPoint(Unit2D point, Unit radius = default)
    {
        _points.Add(point);
        _radii.Add(radius);
        return this;
    }

    public Polygon Build()
    {
        if (_points.Count < 3)
            throw new InvalidOperationException("A polygon must have at least 3 points.");

        var points = new List<Unit2D>();
        for (var i = 0; i < _points.Count; i++)
        {
            MakePoints(points, i);
        }

        return Polygon.FromPoints(points.ToArray());
    }

    private void MakePoints(List<Unit2D> points, int i)
    {
        var radius = _radii[i];
        var pc = _points[i]; // point current

        if (radius.Millimeters <= 0)
        {
            points.Add(pc);
            return;
        }

        var pp = _points[(i - 1) % _points.Count]; // point previous
        var pn = _points[(i + 1) % _points.Count]; // point next

        var lp = pp - pc; // line previous
        var ln = pn - pc; // line next
        
        var dp = lp.Length; // delta previous
        var dn = ln.Length; // delta next

        var lpn = lp.Normalize(); // line previous normalized
        var lnn = ln.Normalize(); // line next normalized
        

        radius = Unit.FromMillimeters(
            Math.Min(radius.Millimeters, Math.Min(dp.Millimeters, dn.Millimeters / 2))
        );

        var origin = pc - (lpn + lnn).Normalize() * radius.Millimeters;
    }
}