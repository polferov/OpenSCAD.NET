using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Modifiers;

public abstract class ModifierBase<TChild>(TChild child) : I2DObject, I3DObject
    where TChild : IDimensionalObject
{
    public TChild Child { get; } = child;

    public abstract char ModifierChar { get; }

    public void Write(StringWriter w, int idt)
    {
        w.Write(ModifierChar);
        Child.Write(w, idt);
    }
}