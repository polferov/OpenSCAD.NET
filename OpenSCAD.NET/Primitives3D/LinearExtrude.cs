using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

/// <summary>
/// Represents a 3D linear extrusion operation, extruding a 2D object to a specified height.
/// </summary>
public class LinearExtrude : IDimensionalObject<Unit3D>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LinearExtrude"/> class with the specified child object and extrusion height.
    /// </summary>
    /// <param name="child">The 2D object to extrude.</param>
    /// <param name="height">The height to extrude the object.</param>
    internal LinearExtrude(IDimensionalObject<Unit2D> child, Unit height)
    {
        Child = child;
        Height = height;
    }

    /// <summary>
    /// Gets the 2D child object to be extruded.
    /// </summary>
    public IDimensionalObject<Unit2D> Child { get; }

    /// <summary>
    /// Gets the height to extrude the child object.
    /// </summary>
    public Unit Height { get; }

    /// <summary>
    /// Writes the OpenSCAD representation of the linear extrusion to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"linear_extrude(height = {Height})");
        Child.Write(w, idt + 1);
    }
}

/// <summary>
/// Extension methods for creating linear extrusion operations.
/// </summary>
public static class LinearExtrudeExtensions
{
    /// <summary>
    /// Creates a <see cref="LinearExtrude"/> operation from a 2D object and extrusion height.
    /// </summary>
    /// <param name="child">The 2D object to extrude.</param>
    /// <param name="height">The height to extrude the object.</param>
    /// <returns>A new <see cref="LinearExtrude"/> instance.</returns>
    public static LinearExtrude Extrude(this IDimensionalObject<Unit2D> child, Unit height)
    {
        return new LinearExtrude(child, height);
    }
}