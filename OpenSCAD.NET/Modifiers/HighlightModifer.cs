using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public class HighlightModifer<TUnit>(IDimensionalObject<TUnit> child) : ModifierBase<TUnit>(child)
    where TUnit : IDimensionalUnit

{
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