using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Primitives3D;

public class LinearExtrude(I2DObject child, Unit height) : I3DObject
{
    public I2DObject Child { get; } = child;
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
    public static LinearExtrude Extrude(this I2DObject child, Unit height)
    {
        return new LinearExtrude(child, height);
    }
}