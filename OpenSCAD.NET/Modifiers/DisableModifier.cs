using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

public class DisableModifier<TUnit> : ModifierBase<TUnit>
    where TUnit : IDimensionalUnit

{
    internal DisableModifier(IDimensionalObject<TUnit> child) : base(child)
    {
    }

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