using System.Numerics;

namespace OpenSCAD.NET.Units;

/// <summary>
/// Represents a two-dimensional unit vector with X and Y components in millimeters.
/// </summary>
public readonly struct Unit2D(Unit x, Unit y) :
    IDimensionalUnit,
    IAdditionOperators<Unit2D, Unit2D, Unit2D>,
    ISubtractionOperators<Unit2D, Unit2D, Unit2D>,
    IMultiplyOperators<Unit2D, decimal, Unit2D>,
    IDivisionOperators<Unit2D, decimal, Unit2D>
{
    /// <summary>
    /// Gets the X component of the vector in millimeters.
    /// </summary>
    public Unit X { get; } = x;

    /// <summary>
    /// Gets the Y component of the vector in millimeters.
    /// </summary>
    public Unit Y { get; } = y;

    /// <summary>
    /// Returns the string representation of the vector.
    /// </summary>
    /// <returns>A string in the format [X, Y].</returns>
    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }

    /// <summary>
    /// Gets the length of the vector, calculated using the Euclidean norm.
    /// </summary>
    public Unit Length =>
        Unit.FromMillimeters(
            (decimal)Math.Sqrt((double)(X.Millimeters * X.Millimeters + Y.Millimeters * Y.Millimeters)));

    /// <summary>
    /// Returns a normalized (unit length) version of this vector.
    /// </summary>
    /// <returns>A new <see cref="Unit2D"/> with length 1.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the vector has zero length.</exception>
    public Unit2D Normalize()
    {
        var length = Length.Millimeters;
        if (length == 0)
            throw new InvalidOperationException("Cannot normalize a zero-length vector.");
        return new Unit2D(
            Unit.FromMillimeters(X.Millimeters / length),
            Unit.FromMillimeters(Y.Millimeters / length)
        );
    }

    /// <summary>
    /// Implicitly converts a tuple of two <see cref="Unit"/> values to a <see cref="Unit2D"/>.
    /// </summary>
    /// <param name="tuple">The tuple containing X and Y components.</param>
    public static implicit operator Unit2D(ValueTuple<Unit, Unit> tuple)
        => new(tuple.Item1, tuple.Item2);

    /// <summary>
    /// Adds two <see cref="Unit2D"/> vectors.
    /// </summary>
    /// <param name="left">The left vector.</param>
    /// <param name="right">The right vector.</param>
    /// <returns>The vector sum.</returns>
    public static Unit2D operator +(Unit2D left, Unit2D right)
        => new(
            left.X + right.X,
            left.Y + right.Y
        );

    /// <summary>
    /// Subtracts one <see cref="Unit2D"/> vector from another.
    /// </summary>
    /// <param name="left">The left vector.</param>
    /// <param name="right">The right vector.</param>
    /// <returns>The vector difference.</returns>
    public static Unit2D operator -(Unit2D left, Unit2D right)
        => new(
            left.X - right.X,
            left.Y - right.Y
        );

    /// <summary>
    /// Multiplies a <see cref="Unit2D"/> vector by a scalar.
    /// </summary>
    /// <param name="left">The vector.</param>
    /// <param name="right">The scalar value.</param>
    /// <returns>The scaled vector.</returns>
    public static Unit2D operator *(Unit2D left, decimal right) =>
        new(
            left.X * right,
            left.Y * right
        );

    /// <summary>
    /// Divides a <see cref="Unit2D"/> vector by a scalar.
    /// </summary>
    /// <param name="left">The vector.</param>
    /// <param name="right">The scalar value.</param>
    /// <returns>The scaled vector.</returns>
    /// <exception cref="DivideByZeroException">Thrown if <paramref name="right"/> is zero.</exception>
    public static Unit2D operator /(Unit2D left, decimal right)
    {
        if (right == 0)
            throw new DivideByZeroException("Cannot divide by zero in Unit3D division.");

        return new(
            left.X / right,
            left.Y / right
        );
    }
}