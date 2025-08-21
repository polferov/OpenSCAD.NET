using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public class ShowOnlyModifier<TUnit> : ModifierBase<TUnit>
    where TUnit : IDimensionalUnit

{
    internal ShowOnlyModifier(IDimensionalObject<TUnit> child) : base(child)
    {
    }

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