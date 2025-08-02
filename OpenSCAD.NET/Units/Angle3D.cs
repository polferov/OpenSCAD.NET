namespace OpenSCAD.NET.Units;

public readonly struct Angle3D(Angle x, Angle y, Angle z)
{
    public Angle X { get; } = x;
    public Angle Y { get; } = y;
    public Angle Z { get; } = z;

    public override string ToString()
    {
        return $"[{X}, {Y}, {Z}]";
    }


    public static implicit operator Angle3D(ValueTuple<Angle, Angle, Angle> tuple)
        => new(tuple.Item1, tuple.Item2, tuple.Item3);
}