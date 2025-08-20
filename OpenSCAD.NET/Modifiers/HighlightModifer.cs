using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Modifiers;

public class HighlightModifer<TChild>(TChild child) : ModifierBase<TChild>(child)
    where TChild : IDimensionalObject
{
    public override char ModifierChar => '#';
}

public static class HighlightModifierExtensions
{
    public static I3DObject Highlight(this I3DObject obj)
    {
        return new HighlightModifer<I3DObject>(obj);
    }

    public static I2DObject Highlight(this I2DObject obj)
    {
        return new HighlightModifer<I2DObject>(obj);
    }
}