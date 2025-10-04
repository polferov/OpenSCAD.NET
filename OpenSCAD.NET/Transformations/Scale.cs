using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

/// <summary>
/// Represents a scale transformation applied to dimensional objects.
/// </summary>
public class Scale<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Scale{TUnit}"/> class with the specified scale and child objects.
    /// </summary>
    /// <param name="scale">The scale factor for each dimension.</param>
    /// <param name="children">The dimensional objects to be scaled.</param>
    internal Scale(TUnit scale, params IDimensionalObject<TUnit>[] children)
    {
        ScaleDimensions = scale;
        Children = children;
    }

    /// <summary>
    /// Gets the scale factor for each dimension.
    /// </summary>
    public TUnit ScaleDimensions { get; }

    /// <inheritdoc />
    public override string Name => "scale";

    /// <summary>
    /// Gets the child objects to be scaled.
    /// </summary>
    public override IDimensionalObject<TUnit>[] Children { get; }

    /// <inheritdoc />
    public override void WriteArgs(StringWriter w)
    {
        w.Write(ScaleDimensions.ToString());
    }
}

/// <summary>
/// Extension methods for applying scale transformations to dimensional objects.
/// </summary>
public static class ScaleExtensions
{
    /// <summary>
    /// Scales the object by the specified scale factor for each dimension.
    /// </summary>
    /// <param name="obj">The object to scale.</param>
    /// <param name="scale">The scale factor for each dimension.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{TUnit}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<TUnit> Scale<TUnit>(this IDimensionalObject<TUnit> obj, TUnit scale) 
        where TUnit : IDimensionalUnit
    {
        return new Scale<TUnit>(scale, obj);
    }

    /// <summary>
    /// Scales a 3D object by the specified scale factors along the X, Y, and Z axes.
    /// </summary>
    /// <param name="obj">The 3D object to scale.</param>
    /// <param name="x">The scale factor along the X axis.</param>
    /// <param name="y">The scale factor along the Y axis.</param>
    /// <param name="z">The scale factor along the Z axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{Unit3D}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<Unit3D> Scale(this IDimensionalObject<Unit3D> obj, Unit x, Unit y, Unit z)
    {
        return new Scale<Unit3D>((x, y, z), obj);
    }

    /// <summary>
    /// Scales a 3D object by the specified scale factor along the X axis.
    /// </summary>
    /// <param name="obj">The 3D object to scale.</param>
    /// <param name="amount">The scale factor along the X axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{Unit3D}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<Unit3D> ScaleX(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Scale<Unit3D>((amount, 1, 1), obj);
    }

    /// <summary>
    /// Scales a 3D object by the specified scale factor along the Y axis.
    /// </summary>
    /// <param name="obj">The 3D object to scale.</param>
    /// <param name="amount">The scale factor along the Y axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{Unit3D}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<Unit3D> ScaleY(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Scale<Unit3D>((1, amount, 1), obj);
    }

    /// <summary>
    /// Scales a 3D object by the specified scale factor along the Z axis.
    /// </summary>
    /// <param name="obj">The 3D object to scale.</param>
    /// <param name="amount">The scale factor along the Z axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{Unit3D}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<Unit3D> ScaleZ(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Scale<Unit3D>((1, 1, amount), obj);
    }

    /// <summary>
    /// Scales a 2D object by the specified scale factors for each dimension.
    /// </summary>
    /// <param name="obj">The 2D object to scale.</param>
    /// <param name="scale">The scale factor for each dimension.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{Unit2D}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<Unit2D> Scale(this IDimensionalObject<Unit2D> obj, Unit2D scale)
    {
        return new Scale<Unit2D>(scale, obj);
    }

    /// <summary>
    /// Scales a 2D object by the specified scale factors along the X and Y axes.
    /// </summary>
    /// <param name="obj">The 2D object to scale.</param>
    /// <param name="x">The scale factor along the X axis.</param>
    /// <param name="y">The scale factor along the Y axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{Unit2D}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<Unit2D> Scale(this IDimensionalObject<Unit2D> obj, Unit x, Unit y)
    {
        return new Scale<Unit2D>((x, y), obj);
    }

    /// <summary>
    /// Scales a 2D object by the specified scale factor along the X axis.
    /// </summary>
    /// <param name="obj">The 2D object to scale.</param>
    /// <param name="amount">The scale factor along the X axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{Unit2D}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<Unit2D> ScaleX(this IDimensionalObject<Unit2D> obj, Unit amount)
    {
        return new Scale<Unit2D>((amount, 1), obj);
    }

    /// <summary>
    /// Scales a 2D object by the specified scale factor along the Y axis.
    /// </summary>
    /// <param name="obj">The 2D object to scale.</param>
    /// <param name="amount">The scale factor along the Y axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Scale{Unit2D}"/> instance representing the scaled object.</returns>
    public static IDimensionalObject<Unit2D> ScaleY(this IDimensionalObject<Unit2D> obj, Unit amount)
    {
        return new Scale<Unit2D>((1, amount), obj);
    }
}