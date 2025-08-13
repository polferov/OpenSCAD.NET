namespace OpenSCAD.NET.Common;

public class FragmentOptions
{
    public uint? Fn { get; set; }
    
    public void Write(StringWriter sw)
    {
        if (Fn.HasValue)
        {
            sw.Write($"$fn = {Fn.Value}, ");
        }
    }
}