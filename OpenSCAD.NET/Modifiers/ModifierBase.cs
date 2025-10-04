using OpenSCAD.NET.Common;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Modifiers;

/// <summary>
/// Base class for modifiers that modify a dimensional object.
/// This includes <see cref="DisableModifier{TUnit}"/> (*) and <see cref="HighlightModifer{TUnit}"/> (#),
/// <see cref="ShowOnlyModifier{TUnit}"/> (!), and <see cref="TransparentModifier{TUnit}"/> (%).
/// </summary>
/// <param name="child">Object to be modified</param>
public abstract class ModifierBase<TUnit>(IDimensionalObject<TUnit> child) : IDimensionalObject<TUnit>
    where TUnit : IDimensionalUnit

{
    /// <summary>
    /// Gets the child object being modified / being affected by the modifier.
    /// </summary>
    public IDimensionalObject<TUnit> Child { get; } = child;

    /// <summary>
    /// Character representing the modifier in OpenSCAD syntax.
    /// Examples include '*', '#', '!', and '%'.
    /// </summary>
    public abstract char ModifierChar { get; }

    /// <inheritdoc />
    public void Write(StringWriter w, int idt)
    {
        w.Write(ModifierChar);
        Child.Write(w, idt);
    }
}