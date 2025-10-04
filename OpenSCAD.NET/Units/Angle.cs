using System.Globalization;

namespace OpenSCAD.NET.Units;

/// <summary>
/// Represents an angle value in degrees, with conversion and formatting utilities.
/// </summary>

public readonly struct Angle
{
    /// <summary>
    /// Gets the angle value in degrees.
    /// </summary>
    public decimal Degrees { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Angle"/> struct with the specified degrees.
    /// </summary>
    /// <param name="degrees">The angle value in degrees.</param>
    private Angle(decimal degrees)
    {
        Degrees = degrees;
    }

    /// <summary>
    /// Returns the string representation of the angle in invariant culture.
    /// </summary>
    /// <returns>The angle value as a string.</returns>
    public override string ToString()
    {
        return Degrees.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Creates a new <see cref="Angle"/> from the specified degrees value.
    /// </summary>
    /// <param name="degrees">The angle value in degrees.</param>
    /// <returns>A new <see cref="Angle"/> instance.</returns>
    public static Angle FromDegrees(decimal degrees)
    {
        return new Angle(degrees);
    }

    /// <summary>
    /// Implicitly converts a decimal value to an <see cref="Angle"/>.
    /// </summary>
    /// <param name="degrees">The angle value in degrees.</param>
    public static implicit operator Angle(decimal degrees)
    {
        return FromDegrees(degrees);
    }
}

/// <summary>
/// Extension methods for creating <see cref="Angle"/> instances from numeric types.
/// </summary>
public static class AngleExtensions
{
    /// <summary>
    /// Converts a decimal value to an <see cref="Angle"/> in degrees.
    /// </summary>
    /// <param name="degrees">The angle value in degrees.</param>
    /// <returns>An <see cref="Angle"/> instance.</returns>
    public static Angle deg(this decimal degrees)
    {
        return Angle.FromDegrees(degrees);
    }

    /// <summary>
    /// Converts an integer value to an <see cref="Angle"/> in degrees.
    /// </summary>
    /// <param name="degrees">The angle value in degrees.</param>
    /// <returns>An <see cref="Angle"/> instance.</returns>
    public static Angle deg(this int degrees)
    {
        return Angle.FromDegrees(degrees);
    }

    /// <summary>
    /// Converts a double value to an <see cref="Angle"/> in degrees.
    /// </summary>
    /// <param name="degrees">The angle value in degrees.</param>
    /// <returns>An <see cref="Angle"/> instance.</returns>
    public static Angle deg(this double degrees)
    {
        return Angle.FromDegrees((decimal)degrees);
    }
}