using System.Text;

namespace OpenSCAD.NET.Common;

public struct FragmentOptions
{
    private FragmentOptions(uint? fn)
    {
        Fn = fn;
    }

    public uint? Fn { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        if (Fn.HasValue)
        {
            sb.Append($", $fn = {Fn.Value}");
        }

        return sb.ToString();
    }

    public readonly void Write(StringWriter w)
    {
        if (!Fn.HasValue)
            return;
        w.WriteLine($"$fn = {Fn};");
    }

    public static FragmentOptions FromFn(uint fn)
    {
        return new FragmentOptions(fn);
    }

    public static readonly FragmentOptions HighRes = new(100);
    public static readonly FragmentOptions MidRes = new(40);
}