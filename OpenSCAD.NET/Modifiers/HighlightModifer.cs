using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

/// <summary>
/// Represents a modifier that highlights a dimensional object.
/// </summary>
public class HighlightModifer<TUnit> : ModifierBase<TUnit>
    where TUnit : IDimensionalUnit

{
    internal HighlightModifer(IDimensionalObject<TUnit> child) : base(child)
    {
    }

    /// <inheritdoc />
    public override char ModifierChar => '#';
}

/// <summary>
/// Extension methods for creating highlight modifiers.
/// </summary>
public static class HighlightModifierExtensions
{
    /// <summary>
    /// Creates a highlight modifier for a dimensional object.
    /// </summary>
    /// <param name="obj">Object to be hughlighted</param>
    public static IDimensionalObject<TUnit> Highlight<TUnit>(this IDimensionalObject<TUnit> obj)
        where TUnit : IDimensionalUnit
    {
        return new HighlightModifer<TUnit>(obj);
    }
}