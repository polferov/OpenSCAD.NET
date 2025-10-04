using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

/// <summary>
/// Represents a modifier that disables the rendering of a dimensional object.
/// </summary>
public class DisableModifier<TUnit> : ModifierBase<TUnit>
    where TUnit : IDimensionalUnit

{
    internal DisableModifier(IDimensionalObject<TUnit> child) : base(child)
    {
    }

    /// <inheritdoc />
    public override char ModifierChar => '*';
}

/// <summary>
/// Extension methods for creating disable modifiers.
/// </summary>
public static class DisableModifierExtensions
{
    /// <summary>
    /// Creates a disable modifier for a dimensional object.
    /// </summary>
    /// <param name="obj">Object to be disabled</param>
    public static IDimensionalObject<TUnit> Disable<TUnit>(this IDimensionalObject<TUnit> obj)
        where TUnit : IDimensionalUnit
    {
        return new DisableModifier<TUnit>(obj);
    }
}