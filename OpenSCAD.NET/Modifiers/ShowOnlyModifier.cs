using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.Modifiers;

public class ShowOnlyModifier<TChild>(TChild child) : ModifierBase<TChild>(child)
    where TChild : IDimensionalObject
{
    public override char ModifierChar => '!';
}

public static class ShowOnlyModifierExtensions
{
    public static I3DObject ShowOnly(this I3DObject obj)
    {
        return new ShowOnlyModifier<I3DObject>(obj);
    }

    public static I2DObject ShowOnly(this I2DObject obj)
    {
        return new ShowOnlyModifier<I2DObject>(obj);
    }
}