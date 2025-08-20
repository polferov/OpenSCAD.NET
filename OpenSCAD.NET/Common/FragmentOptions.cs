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

    public static FragmentOptions FromFn(uint fn)
    {
        return new FragmentOptions(fn);
    }
    
    public static readonly FragmentOptions HighRes = new FragmentOptions(100);
}