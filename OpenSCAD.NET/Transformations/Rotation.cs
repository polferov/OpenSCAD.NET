using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

/// <summary>
/// Represents a rotation transformation applied to dimensional objects.
/// </summary>
public class Rotation<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rotation{TUnit}"/> class with the specified rotation angle and child objects.
    /// </summary>
    /// <param name="angle">The rotation angle in 3D (x, y, z).</param>
    /// <param name="children">The dimensional objects to be rotated.</param>
    internal Rotation(Angle3D angle, params IDimensionalObject<TUnit>[] children)
    {
        Angle = angle;
        Children = children;
    }

    /// <inheritdoc />
    public override string Name => "rotate";

    /// <summary>
    /// Gets the rotation angle in 3D (x, y, z).
    /// </summary>
    public Angle3D Angle { get; }

    /// <summary>
    /// Gets the child objects to be rotated.
    /// </summary>
    public override IDimensionalObject<TUnit>[] Children { get; }

    /// <inheritdoc />
    public override void WriteArgs(StringWriter w)
    {
        w.Write(Angle.ToString());
    }
}

/// <summary>
/// Extension methods for applying rotation transformations to dimensional objects.
/// </summary>
public static class RotationExtensions
{
    /// <summary>
    /// Rotates the object by the specified 3D angle.
    /// </summary>
    /// <param name="obj">The object to rotate.</param>
    /// <param name="amount">The rotation angle in 3D (x, y, z).</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Rotation{TUnit}"/> instance representing the rotated object.</returns>
    public static IDimensionalObject<TUnit> Rotate<TUnit>(this IDimensionalObject<TUnit> obj, Angle3D amount)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>(amount, obj);
    }

    /// <summary>
    /// Rotates the object by the specified angles around the X, Y, and Z axes.
    /// </summary>
    /// <param name="obj">The object to rotate.</param>
    /// <param name="x">The rotation angle around the X axis.</param>
    /// <param name="y">The rotation angle around the Y axis.</param>
    /// <param name="z">The rotation angle around the Z axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Rotation{TUnit}"/> instance representing the rotated object.</returns>
    public static IDimensionalObject<TUnit> Rotate<TUnit>(this IDimensionalObject<TUnit> obj, Angle x, Angle y, Angle z)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>((x, y, z), obj);
    }

    /// <summary>
    /// Rotates the object by the specified angle around the X axis.
    /// </summary>
    /// <param name="obj">The object to rotate.</param>
    /// <param name="amount">The rotation angle around the X axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Rotation{TUnit}"/> instance representing the rotated object.</returns>
    public static IDimensionalObject<TUnit> RotateX<TUnit>(this IDimensionalObject<TUnit> obj, Angle amount)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>((amount, 0, 0), obj);
    }

    /// <summary>
    /// Rotates the object by the specified angle around the Y axis.
    /// </summary>
    /// <param name="obj">The object to rotate.</param>
    /// <param name="amount">The rotation angle around the Y axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Rotation{TUnit}"/> instance representing the rotated object.</returns>
    public static IDimensionalObject<TUnit> RotateY<TUnit>(this IDimensionalObject<TUnit> obj, Angle amount)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>((0, amount, 0), obj);
    }

    /// <summary>
    /// Rotates the object by the specified angle around the Z axis.
    /// </summary>
    /// <param name="obj">The object to rotate.</param>
    /// <param name="amount">The rotation angle around the Z axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Rotation{TUnit}"/> instance representing the rotated object.</returns>
    public static IDimensionalObject<TUnit> RotateZ<TUnit>(this IDimensionalObject<TUnit> obj, Angle amount)
        where TUnit : IDimensionalUnit
    {
        return new Rotation<TUnit>((0, 0, amount), obj);
    }
}