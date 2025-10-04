using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

/// <summary>
/// Represents a modifier that makes a dimensional object transparent.
/// </summary>
public class TransparentModifier<TUnit> : ModifierBase<TUnit>
    where TUnit : IDimensionalUnit

{
    internal TransparentModifier(IDimensionalObject<TUnit> child) : base(child)
    {
    }

    /// <inheritdoc />
    public override char ModifierChar => '%';
}

/// <summary>
/// Extension methods for creating transparent modifiers.
/// </summary>
public static class TransparentModifierExtensions
{
    /// <summary>
    /// Makes the specified dimensional object transparent.
    /// </summary>
    /// <param name="obj">object to be made transparent</param>
    public static IDimensionalObject<TUnit> Transparent<TUnit>(this IDimensionalObject<TUnit> obj)
        where TUnit : IDimensionalUnit
    {
        return new TransparentModifier<TUnit>(obj);
    }
}