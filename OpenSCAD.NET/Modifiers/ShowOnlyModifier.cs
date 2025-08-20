using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public class ShowOnlyModifier<TUnit>(IDimensionalObject<TUnit> child) : ModifierBase<TUnit>(child)
    where TUnit : IDimensionalUnit

{
    public override char ModifierChar => '!';
}

public static class ShowOnlyModifierExtensions
{
    public static IDimensionalObject<TUnit> ShowOnly<TUnit>(this IDimensionalObject<TUnit> obj)
        where TUnit : IDimensionalUnit
    {
        return new ShowOnlyModifier<TUnit>(obj);
    }
}