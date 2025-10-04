namespace OpenSCAD.NET.Units;

/// <summary>
/// Represents a 3D angle with X, Y, and Z components, used for rotation and transformation operations.
/// </summary>
/// <remarks>
/// Provides value semantics and implicit conversion from a tuple of three <see cref="Angle"/> values.
/// </remarks>
public readonly struct Angle3D
{
    /// <summary>
    /// Gets the angle component along the X axis.
    /// </summary>
    public Angle X { get; }

    /// <summary>
    /// Gets the angle component along the Y axis.
    /// </summary>
    public Angle Y { get; }

    /// <summary>
    /// Gets the angle component along the Z axis.
    /// </summary>
    public Angle Z { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Angle3D"/> struct with the specified X, Y, and Z angles.
    /// </summary>
    /// <param name="x">The angle along the X axis.</param>
    /// <param name="y">The angle along the Y axis.</param>
    /// <param name="z">The angle along the Z axis.</param>
    public Angle3D(Angle x, Angle y, Angle z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Returns the string representation of the 3D angle in the format [X, Y, Z].
    /// </summary>
    /// <returns>A string representing the angle components.</returns>
    public override string ToString()
    {
        return $"[{X}, {Y}, {Z}]";
    }

    /// <summary>
    /// Implicitly converts a tuple of three <see cref="Angle"/> values to an <see cref="Angle3D"/>.
    /// </summary>
    /// <param name="tuple">A tuple containing X, Y, and Z angles.</param>
    public static implicit operator Angle3D((Angle, Angle, Angle) tuple)
        => new Angle3D(tuple.Item1, tuple.Item2, tuple.Item3);
}