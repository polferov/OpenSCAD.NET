using System.Numerics;

namespace OpenSCAD.NET.Units;

/// <summary>
/// Represents a three-dimensional unit vector with X, Y, and Z components in millimeters.
/// </summary>
public readonly struct Unit3D(Unit x, Unit y, Unit z) :
    IDimensionalUnit,
    IAdditionOperators<Unit3D, Unit3D, Unit3D>,
    IMultiplyOperators<Unit3D, decimal, Unit3D>,
    IDivisionOperators<Unit3D, decimal, Unit3D>
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
    /// Gets the Z component of the vector in millimeters.
    /// </summary>
    public Unit Z { get; } = z;

    /// <summary>
    /// Returns the string representation of the vector.
    /// </summary>
    /// <returns>A string in the format [X, Y, Z].</returns>
    public override string ToString()
    {
        return $"[{X}, {Y}, {Z}]";
    }

    /// <summary>
    /// Implicitly converts a tuple of three <see cref="Unit"/> values to a <see cref="Unit3D"/>.
    /// </summary>
    /// <param name="tuple">The tuple containing X, Y, and Z components.</param>
    public static implicit operator Unit3D(ValueTuple<Unit, Unit, Unit> tuple)
        => new(tuple.Item1, tuple.Item2, tuple.Item3);

    /// <summary>
    /// Adds two <see cref="Unit3D"/> vectors.
    /// </summary>
    /// <param name="left">The left vector.</param>
    /// <param name="right">The right vector.</param>
    /// <returns>The vector sum.</returns>
    public static Unit3D operator +(Unit3D left, Unit3D right)
        => new(
            left.X + right.X,
            left.Y + right.Y,
            left.Z + right.Z
        );

    /// <summary>
    /// Multiplies a <see cref="Unit3D"/> vector by a scalar.
    /// </summary>
    /// <param name="left">The vector.</param>
    /// <param name="right">The scalar value.</param>
    /// <returns>The scaled vector.</returns>
    public static Unit3D operator *(Unit3D left, decimal right) =>
        new(
            left.X * right,
            left.Y * right,
            left.Z * right
        );

    /// <summary>
    /// Divides a <see cref="Unit3D"/> vector by a scalar.
    /// </summary>
    /// <param name="left">The vector.</param>
    /// <param name="right">The scalar value.</param>
    /// <returns>The scaled vector.</returns>
    /// <exception cref="DivideByZeroException">Thrown if <paramref name="right"/> is zero.</exception>
    public static Unit3D operator /(Unit3D left, decimal right)
    {
        if (right == 0)
            throw new DivideByZeroException("Cannot divide by zero in Unit3D division.");

        return new(
            left.X / right,
            left.Y / right,
            left.Z / right
        );
    }
}