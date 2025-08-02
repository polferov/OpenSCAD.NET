using System.Numerics;

namespace OpenSCAD.NET.Units;

public readonly struct Unit3D(Unit x, Unit y, Unit z) :
    IAdditionOperators<Unit3D, Unit3D, Unit3D>,
    IMultiplyOperators<Unit3D, decimal, Unit3D>,
    IDivisionOperators<Unit3D, decimal, Unit3D>
{
    public Unit X { get; } = x;
    public Unit Y { get; } = y;
    public Unit Z { get; } = z;

    public override string ToString()
    {
        return $"[{X}, {Y}, {Z}]";
    }

    public static implicit operator Unit3D(ValueTuple<Unit, Unit, Unit> tuple)
        => new(tuple.Item1, tuple.Item2, tuple.Item3);

    public static Unit3D operator +(Unit3D left, Unit3D right)
        => new(
            left.X + right.X,
            left.Y + right.Y,
            left.Z + right.Z
        );

    public static Unit3D operator *(Unit3D left, decimal right) =>
        new(
            left.X * right,
            left.Y * right,
            left.Z * right
        );

    public static Unit3D operator /(Unit3D left, decimal right)
    {
        if (right == 0)
            throw new DivideByZeroException("Cannot divide by zero in Unit3D division.");

        return new(
            left.X / right,
            left.Y / right,
            left.Z / right
        );
    }
}