using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public class TransparentModifier<TUnit>(IDimensionalObject<TUnit> child) : ModifierBase<TUnit>(child)
    where TUnit : IDimensionalUnit

{
    public override char ModifierChar => '%';
}

public static class TransparentModifierExtensions
{
    public static IDimensionalObject<TUnit> Transparent<TUnit>(this IDimensionalObject<TUnit> obj)
        where TUnit : IDimensionalUnit
    {
        return new TransparentModifier<TUnit>(obj);
    }
}