using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public abstract class ModifierBase<TUnit>(IDimensionalObject<TUnit> child) : IDimensionalObject<TUnit>
    where TUnit : IDimensionalUnit

{
    public IDimensionalObject<TUnit> Child { get; } = child;

    public abstract char ModifierChar { get; }

    public void Write(StringWriter w, int idt)
    {
        w.Write(ModifierChar);
        Child.Write(w, idt);
    }
}