using OpenSCAD.NET.Primitives2D;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Extended2D;

/// <summary>
/// Provides a fluent API for building 2D polygons by specifying points and relative movements.
/// </summary>
public class PolygonBuilder
{
    private readonly List<Unit2D> _points;

    /// <summary>
    /// Gets the current point (last added) in the polygon, or (0, 0) if none exist.
    /// </summary>
    public Unit2D Point => _points.LastOrDefault(new Unit2D(0, 0));

    /// <summary>
    /// Initializes a new instance of the <see cref="PolygonBuilder"/> class with the specified points.
    /// </summary>
    /// <param name="points">The initial list of points for the polygon.</param>
    private PolygonBuilder(List<Unit2D> points)
    {
        _points = points;
    }

    /// <summary>
    /// Creates a new <see cref="PolygonBuilder"/> starting from the specified point.
    /// </summary>
    /// <param name="point">The starting point of the polygon.</param>
    /// <returns>A new <see cref="PolygonBuilder"/> instance.</returns>
    public static PolygonBuilder FromPoint(Unit2D point)
    {
        return new PolygonBuilder([point]);
    }

    /// <summary>
    /// Adds a point to the polygon.
    /// </summary>
    /// <param name="point">The point to add.</param>
    /// <returns>The current <see cref="PolygonBuilder"/> instance for chaining.</returns>
    public PolygonBuilder AddPoint(Unit2D point)
    {
        _points.Add(point);
        return this;
    }

    /// <summary>
    /// Adds a point to the polygon by moving from the current point by the specified offset.
    /// </summary>
    /// <param name="offset">The offset to move from the current point.</param>
    /// <returns>The current <see cref="PolygonBuilder"/> instance for chaining.</returns>
    public PolygonBuilder ThenMove(Unit2D offset)
    {
        return AddPoint(Point + offset);
    }

    /// <summary>
    /// Adds a point to the polygon by moving from the current point by the specified X and Y offsets.
    /// </summary>
    /// <param name="offsetX">The offset to move along the X axis.</param>
    /// <param name="offsetY">The offset to move along the Y axis.</param>
    /// <returns>The current <see cref="PolygonBuilder"/> instance for chaining.</returns>
    public PolygonBuilder ThenMove(Unit offsetX, Unit offsetY)
    {
        return AddPoint(Point + (offsetX, offsetY));
    }

    /// <summary>
    /// Adds a point to the polygon by moving from the current point along the X axis.
    /// </summary>
    /// <param name="offset">The offset to move along the X axis.</param>
    /// <returns>The current <see cref="PolygonBuilder"/> instance for chaining.</returns>
    public PolygonBuilder ThenMoveX(Unit offset)
    {
        return ThenMove(offset, 0);
    }

    /// <summary>
    /// Adds a point to the polygon by moving from the current point along the Y axis.
    /// </summary>
    /// <param name="offset">The offset to move along the Y axis.</param>
    /// <returns>The current <see cref="PolygonBuilder"/> instance for chaining.</returns>
    public PolygonBuilder ThenMoveY(Unit offset)
    {
        return ThenMove(0, offset);
    }

    /// <summary>
    /// Builds the polygon from the specified points.
    /// </summary>
    /// <returns>A <see cref="Polygon"/> instance representing the constructed polygon.</returns>
    /// <exception cref="InvalidOperationException">Thrown if fewer than 3 points have been added.</exception>
    public Polygon Build()
    {
        if (_points.Count < 3)
            throw new InvalidOperationException("A polygon must have at least 3 points.");

        return Polygon.FromPoints(_points.ToArray());
    }
}