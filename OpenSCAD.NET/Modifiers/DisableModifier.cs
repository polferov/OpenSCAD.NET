using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public class DisableModifier<TUnit>(IDimensionalObject<TUnit> child) : ModifierBase<TUnit>(child)
    where TUnit : IDimensionalUnit

{
    public override char ModifierChar => '*';
}

public static class DisableModifierExtensions
{
    public static IDimensionalObject<TUnit> Disable<TUnit>(this IDimensionalObject<TUnit> obj)
        where TUnit : IDimensionalUnit
    {
        return new DisableModifier<TUnit>(obj);
    }
}