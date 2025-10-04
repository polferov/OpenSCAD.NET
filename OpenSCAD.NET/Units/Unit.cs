// ReSharper disable InconsistentNaming

using System.Globalization;
using System.Numerics;

namespace OpenSCAD.NET.Units;

/// <summary>
/// Represents a dimensional unit in millimeters, supporting arithmetic operations and conversions.
/// </summary>
public readonly struct Unit :
    IDimensionalUnit,
    IAdditionOperators<Unit, Unit, Unit>,
    ISubtractionOperators<Unit, Unit, Unit>,
    IUnaryNegationOperators<Unit, Unit>,
    IMultiplyOperators<Unit, decimal, Unit>,
    IDivisionOperators<Unit, decimal, Unit>
{
    /// <summary>
    /// Gets the value of the unit in millimeters.
    /// </summary>
    public decimal Millimeters { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Unit"/> struct with the specified millimeter value.
    /// </summary>
    /// <param name="mm">The value in millimeters.</param>
    private Unit(decimal mm)
    {
        Millimeters = mm;
    }

    /// <summary>
    /// Returns the string representation of the unit in invariant culture.
    /// </summary>
    /// <returns>The millimeter value as a string.</returns>
    public override string ToString()
    {
        return Millimeters.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Implicitly converts an integer value to a <see cref="Unit"/> in millimeters.
    /// </summary>
    /// <param name="mm">The value in millimeters.</param>
    public static implicit operator Unit(int mm) // to be able to just wire 0
        => new(mm);

    /// <summary>
    /// Creates a new <see cref="Unit"/> from the specified millimeter value.
    /// </summary>
    /// <param name="mm">The value in millimeters.</param>
    /// <returns>A new <see cref="Unit"/> instance.</returns>
    public static Unit FromMillimeters(decimal mm)
        => new(mm);

    /// <summary>
    /// Adds two <see cref="Unit"/> values.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The sum of the two units.</returns>
    public static Unit operator +(Unit left, Unit right)
        => new(left.Millimeters + right.Millimeters);

    /// <summary>
    /// Subtracts one <see cref="Unit"/> value from another.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The difference of the two units.</returns>
    public static Unit operator -(Unit left, Unit right)
        => new(left.Millimeters - right.Millimeters);

    /// <summary>
    /// Multiplies a <see cref="Unit"/> value by a decimal factor.
    /// </summary>
    /// <param name="left">The unit value.</param>
    /// <param name="right">The decimal factor.</param>
    /// <returns>The scaled unit value.</returns>
    public static Unit operator *(Unit left, decimal right)
        => new(left.Millimeters * right);

    /// <summary>
    /// Divides a <see cref="Unit"/> value by a decimal divisor.
    /// </summary>
    /// <param name="left">The unit value.</param>
    /// <param name="right">The decimal divisor.</param>
    /// <returns>The scaled unit value.</returns>
    /// <exception cref="DivideByZeroException">Thrown when <paramref name="right"/> is zero.</exception>
    public static Unit operator /(Unit left, decimal right)
        => right == 0
            ? throw new DivideByZeroException("Cannot divide by zero in Unit division.")
            : new Unit(left.Millimeters / right);

    /// <summary>
    /// Converts this <see cref="Unit"/> to a <see cref="Unit2D"/> with equal X and Y values.
    /// </summary>
    /// <returns>A <see cref="Unit2D"/> instance.</returns>
    public Unit2D ToUnit2D()
        => new Unit2D(this, this);

    /// <summary>
    /// Converts this <see cref="Unit"/> to a <see cref="Unit3D"/> with equal X, Y, and Z values.
    /// </summary>
    /// <returns>A <see cref="Unit3D"/> instance.</returns>
    public Unit3D ToUnit3D()
        => new Unit3D(this, this, this);

    /// <summary>
    /// Negates the <see cref="Unit"/> value.
    /// </summary>
    /// <param name="value">The unit value to negate.</param>
    /// <returns>The negated unit value.</returns>
    public static Unit operator -(Unit value)
        => new(-value.Millimeters);
}

/// <summary>
/// Extension methods for creating <see cref="Unit"/> instances from numeric types.
/// </summary>
public static class LengthUnitExtensions
{
    /// <summary>
    /// Converts a decimal value to a <see cref="Unit"/> in millimeters.
    /// </summary>
    /// <param name="mm">The value in millimeters.</param>
    /// <returns>A <see cref="Unit"/> instance.</returns>
    public static Unit mm(this decimal mm)
        => Unit.FromMillimeters(mm);

    /// <summary>
    /// Converts an integer value to a <see cref="Unit"/> in millimeters.
    /// </summary>
    /// <param name="mm">The value in millimeters.</param>
    /// <returns>A <see cref="Unit"/> instance.</returns>
    public static Unit mm(this int mm)
        => Unit.FromMillimeters(mm);

    /// <summary>
    /// Converts a double value to a <see cref="Unit"/> in millimeters.
    /// </summary>
    /// <param name="mm">The value in millimeters.</param>
    /// <returns>A <see cref="Unit"/> instance.</returns>
    public static Unit mm(this double mm)
        => Unit.FromMillimeters((decimal)mm);
}