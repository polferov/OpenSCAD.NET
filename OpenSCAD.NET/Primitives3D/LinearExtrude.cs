using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class LinearExtrude(IDimensionalObject<Unit2D> child, Unit height) : IDimensionalObject<Unit3D>
{
    public IDimensionalObject<Unit2D> Child { get; } = child;
    public Unit Height { get; } = height;

    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"linear_extrude(height = {Height})");
        Child.Write(w, idt + 1);
    }
}

public static class LinearExtrudeExtensions
{
    public static LinearExtrude Extrude(this IDimensionalObject<Unit2D> child, Unit height)
    {
        return new LinearExtrude(child, height);
    }
}