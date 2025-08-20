using System.Numerics;

namespace OpenSCAD.NET.Units;

public readonly struct Unit2D(Unit x, Unit y) :
    IAdditionOperators<Unit2D, Unit2D, Unit2D>,
    IMultiplyOperators<Unit2D, decimal, Unit2D>,
    IDivisionOperators<Unit2D, decimal, Unit2D>
{
    public Unit X { get; } = x;
    public Unit Y { get; } = y;

    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }

    public static implicit operator Unit2D(ValueTuple<Unit, Unit> tuple)
        => new(tuple.Item1, tuple.Item2);

    public static Unit2D operator +(Unit2D left, Unit2D right)
        => new(
            left.X + right.X,
            left.Y + right.Y
        );

    public static Unit2D operator *(Unit2D left, decimal right) =>
        new(
            left.X * right,
            left.Y * right
        );

    public static Unit2D operator /(Unit2D left, decimal right)
    {
        if (right == 0)
            throw new DivideByZeroException("Cannot divide by zero in Unit3D division.");

        return new(
            left.X / right,
            left.Y / right
        );
    }
}