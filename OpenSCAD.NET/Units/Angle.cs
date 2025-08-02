using System.Globalization;

// ReSharper disable InconsistentNaming

namespace OpenSCAD.NET.Units;

public readonly struct Angle
{
    public decimal Degrees { get; }

    private Angle(decimal degrees)
    {
        Degrees = degrees;
    }

    public override string ToString()
    {
        return Degrees.ToString(CultureInfo.InvariantCulture);
    }

    public static Angle FromDegrees(decimal degrees)
    {
        return new Angle(degrees);
    }

    public static implicit operator Angle(decimal degrees)
    {
        return FromDegrees(degrees);
    }
}

public static class AngleExtensions
{
    public static Angle deg(this decimal degrees)
    {
        return Angle.FromDegrees(degrees);
    }

    public static Angle deg(this int degrees)
    {
        return Angle.FromDegrees(degrees);
    }

    public static Angle deg(this double degrees)
    {
        return Angle.FromDegrees((decimal)degrees);
    }
}