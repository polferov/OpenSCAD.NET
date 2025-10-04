using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Transformations;

/// <summary>
/// Represents a translation transformation applied to dimensional objects.
/// </summary>
public class Translation<TUnit> : ObjectWithChildren<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Translation{TUnit}"/> class with the specified translation amount and child objects.
    /// </summary>
    /// <param name="amount">The translation amount for each dimension.</param>
    /// <param name="children">The dimensional objects to be translated.</param>
    internal Translation(TUnit amount, params IDimensionalObject<TUnit>[] children)
    {
        Amount = amount;
        Children = children;
    }

    /// <summary>
    /// Gets the translation amount for each dimension.
    /// </summary>
    public TUnit Amount { get; }

    /// <summary>
    /// Gets the child objects to be translated.
    /// </summary>
    public override IDimensionalObject<TUnit>[] Children { get; }

    /// <inheritdoc />
    public override string Name => "translate";

    /// <inheritdoc />
    public override void WriteArgs(StringWriter w)
    {
        w.Write(Amount.ToString());
    }
}

/// <summary>
/// Extension methods for applying translation transformations to dimensional objects.
/// </summary>
public static class TranslationExtensions
{
    /// <summary>
    /// Translates the object by the specified amount for each dimension.
    /// </summary>
    /// <param name="obj">The object to translate.</param>
    /// <param name="amount">The translation amount for each dimension.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Translation{TUnit}"/> instance representing the translated object.</returns>
    public static IDimensionalObject<TUnit> Translate<TUnit>(this IDimensionalObject<TUnit> obj, TUnit amount)
        where TUnit : IDimensionalUnit
    {
        return new Translation<TUnit>(amount, obj);
    }

    /// <summary>
    /// Translates a 3D object by the specified amounts along the X, Y, and Z axes.
    /// </summary>
    /// <param name="obj">The 3D object to translate.</param>
    /// <param name="x">The translation amount along the X axis.</param>
    /// <param name="y">The translation amount along the Y axis.</param>
    /// <param name="z">The translation amount along the Z axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Translation{Unit3D}"/> instance representing the translated object.</returns>
    public static IDimensionalObject<Unit3D> Translate(this IDimensionalObject<Unit3D> obj, Unit x, Unit y, Unit z)
    {
        return new Translation<Unit3D>((x, y, z), obj);
    }

    /// <summary>
    /// Translates a 2D object by the specified amounts along the X and Y axes.
    /// </summary>
    /// <param name="obj">The 2D object to translate.</param>
    /// <param name="x">The translation amount along the X axis.</param>
    /// <param name="y">The translation amount along the Y axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Translation{Unit2D}"/> instance representing the translated object.</returns>
    public static IDimensionalObject<Unit2D> Translate(this IDimensionalObject<Unit2D> obj, Unit x, Unit y)
    {
        return new Translation<Unit2D>((x, y), obj);
    }

    /// <summary>
    /// Translates a 3D object by the specified amount along the X axis.
    /// </summary>
    /// <param name="obj">The 3D object to translate.</param>
    /// <param name="amount">The translation amount along the X axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Translation{Unit3D}"/> instance representing the translated object.</returns>
    public static IDimensionalObject<Unit3D> TranslateX(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Translation<Unit3D>((amount, 0, 0), obj);
    }

    /// <summary>
    /// Translates a 2D object by the specified amount along the X axis.
    /// </summary>
    /// <param name="obj">The 2D object to translate.</param>
    /// <param name="amount">The translation amount along the X axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Translation{Unit2D}"/> instance representing the translated object.</returns>
    public static IDimensionalObject<Unit2D> TranslateX(this IDimensionalObject<Unit2D> obj, Unit amount)
    {
        return new Translation<Unit2D>((amount, 0), obj);
    }

    /// <summary>
    /// Translates a 3D object by the specified amount along the Y axis.
    /// </summary>
    /// <param name="obj">The 3D object to translate.</param>
    /// <param name="amount">The translation amount along the Y axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Translation{Unit3D}"/> instance representing the translated object.</returns>
    public static IDimensionalObject<Unit3D> TranslateY(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Translation<Unit3D>((0, amount, 0), obj);
    }

    /// <summary>
    /// Translates a 2D object by the specified amount along the Y axis.
    /// </summary>
    /// <param name="obj">The 2D object to translate.</param>
    /// <param name="amount">The translation amount along the Y axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Translation{Unit2D}"/> instance representing the translated object.</returns>
    public static IDimensionalObject<Unit2D> TranslateY(this IDimensionalObject<Unit2D> obj, Unit amount)
    {
        return new Translation<Unit2D>((0, amount), obj);
    }

    /// <summary>
    /// Translates a 3D object by the specified amount along the Z axis.
    /// </summary>
    /// <param name="obj">The 3D object to translate.</param>
    /// <param name="amount">The translation amount along the Z axis.</param>
    /// <returns>A new <see cref="OpenSCAD.NET.Transformations.Translation{Unit3D}"/> instance representing the translated object.</returns>
    public static IDimensionalObject<Unit3D> TranslateZ(this IDimensionalObject<Unit3D> obj, Unit amount)
    {
        return new Translation<Unit3D>((0, 0, amount), obj);
    }
}