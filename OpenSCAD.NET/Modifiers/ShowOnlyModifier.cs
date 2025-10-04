using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

/// <summary>
/// Represents a modifier that shows only the specified dimensional object.
/// </summary>
public class ShowOnlyModifier<TUnit> : ModifierBase<TUnit>
    where TUnit : IDimensionalUnit

{
    internal ShowOnlyModifier(IDimensionalObject<TUnit> child) : base(child)
    {
    }

    /// <inheritdoc />
    public override char ModifierChar => '!';
}

/// <summary>
/// Extension methods for creating show-only modifiers.
/// </summary>
public static class ShowOnlyModifierExtensions
{
    /// <summary>
    /// Only shows the specified dimensional object.
    /// </summary>
    /// <param name="obj">Object to be shown</param>
    public static IDimensionalObject<TUnit> ShowOnly<TUnit>(this IDimensionalObject<TUnit> obj)
        where TUnit : IDimensionalUnit
    {
        return new ShowOnlyModifier<TUnit>(obj);
    }
}