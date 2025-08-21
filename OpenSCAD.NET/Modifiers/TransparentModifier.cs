using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public class TransparentModifier<TUnit> : ModifierBase<TUnit>
    where TUnit : IDimensionalUnit

{
    internal TransparentModifier(IDimensionalObject<TUnit> child) : base(child)
    {
    }

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