using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Modifiers;

public class TransparentModifier<TChild>(TChild child) : ModifierBase<TChild>(child)
    where TChild : IDimensionalObject
{
    public override char ModifierChar => '%';
}

public static class TransparentModifierExtensions
{
    public static I3DObject Transparent(this I3DObject obj)
    {
        return new TransparentModifier<I3DObject>(obj);
    }

    public static I2DObject Transparent(this I2DObject obj)
    {
        return new TransparentModifier<I2DObject>(obj);
    }
}