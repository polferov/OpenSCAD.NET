using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public class HighlightModifer<TUnit> : ModifierBase<TUnit>
    where TUnit : IDimensionalUnit

{
    internal HighlightModifer(IDimensionalObject<TUnit> child) : base(child)
    {
    }

    public override char ModifierChar => '#';
}

public static class HighlightModifierExtensions
{
    public static IDimensionalObject<TUnit> Highlight<TUnit>(this IDimensionalObject<TUnit> obj)
        where TUnit : IDimensionalUnit
    {
        return new HighlightModifer<TUnit>(obj);
    }
}