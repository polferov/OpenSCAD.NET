using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Modifiers;

public class DisableModifier<TChild>(TChild child) : ModifierBase<TChild>(child)
    where TChild : IDimensionalObject
{
    public override char ModifierChar => '*';
}

public static class DisableModifierExtensions
{
    public static I3DObject Disable(this I3DObject obj)
    {
        return new DisableModifier<I3DObject>(obj);
    }

    public static I2DObject Disable(this I2DObject obj)
    {
        return new DisableModifier<I2DObject>(obj);
    }
}