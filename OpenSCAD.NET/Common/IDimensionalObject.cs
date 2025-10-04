using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Common;

/// <summary>
/// Represents a dimensional object that can be rendered in OpenSCAD.
/// The dimensionality of this object is not specified.
/// This is the non-generic base interface for <see cref="IDimensionalObject{TUnit}"/>.
/// </summary>
/// <remarks>
/// Dimensional objects should always be read-only.
/// </remarks>
public interface IDimensionalObject
{
    /// <summary>
    /// Writes the OpenSCAD representation of this object to the specified <see cref="StringWriter"/>.
    /// Indentation level is specified by <paramref name="idt"/>.
    /// Indentation should not be written by hand.
    /// Use <see cref="StringUtil.WriteIndentation"/> (or <see cref="StringUtil.Indent"/>) for this purpose.
    /// One level of indentation is considered to be 4 spaces.
    /// </summary>
    /// <param name="w">Writer</param>
    /// <param name="idt">Indentation level</param>
    void Write(StringWriter w, int idt);
}

/// <summary>
/// Object that has a specific dimensional unit type.
/// This means, an object can be of type <see cref="Unit2D"/> to represent a 2D object,
/// or of type <see cref="Unit3D"/> to represent a 3D object.
/// Other types of dimensional units can be defined by implementing <see cref="IDimensionalUnit"/>,
/// although it is unlikely that this will be necessary.
/// </summary>
/// <typeparam name="TUnit">Dimensional unit type</typeparam>
/// <remarks>
/// Dimensional objects should always be read-only.
/// </remarks>
public interface IDimensionalObject<TUnit> : IDimensionalObject
    where TUnit : IDimensionalUnit;