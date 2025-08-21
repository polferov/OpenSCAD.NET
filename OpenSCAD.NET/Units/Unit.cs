// ReSharper disable InconsistentNaming

using System.Globalization;
using System.Numerics;

namespace OpenSCAD.NET.Units;

public readonly struct Unit :
    IDimensionalUnit,
    IAdditionOperators<Unit, Unit, Unit>,
    IMultiplyOperators<Unit, decimal, Unit>,
    IDivisionOperators<Unit, decimal, Unit>
{
    public decimal Millimeters { get; }

    private Unit(decimal mm)
    {
        Millimeters = mm;
    }

    public override string ToString()
    {
        return Millimeters.ToString(CultureInfo.InvariantCulture);
    }

    public static implicit operator Unit(int mm) // to be able to just wire 0
        => new(mm);

    public static Unit FromMillimeters(decimal mm)
        => new(mm);

    public static Unit operator +(Unit left, Unit right)
        => new(left.Millimeters + right.Millimeters);

    public static Unit operator *(Unit left, decimal right)
        => new(left.Millimeters * right);

    public static Unit operator /(Unit left, decimal right)
        => right == 0
            ? throw new DivideByZeroException("Cannot divide by zero in Unit division.")
            : new Unit(left.Millimeters / right);

    public Unit2D ToUnit2D()
        => new Unit2D(this, this);

    public Unit3D ToUnit3D()
        => new Unit3D(this, this, this);
}

public static class LengthUnitExtensions
{
    public static Unit mm(this decimal mm)
        => Unit.FromMillimeters(mm);

    public static Unit mm(this int mm)
        => Unit.FromMillimeters(mm);

    public static Unit mm(this double mm)
        => Unit.FromMillimeters((decimal)mm);
}