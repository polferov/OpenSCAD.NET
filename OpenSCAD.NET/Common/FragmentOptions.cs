using System.Text;

namespace OpenSCAD.NET.Common;

/// <summary>
/// Represents options for controlling the number of fragments in OpenSCAD objects.
/// </summary>
public struct FragmentOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FragmentOptions"/> struct.
    /// </summary>
    /// <param name="fn">The number of fragments ($fn) to use.</param>
    private FragmentOptions(uint? fn)
    {
        Fn = fn;
    }

    /// <summary>
    /// Gets the number of fragments ($fn) to use.
    /// </summary>
    public uint? Fn { get; }

    /// <summary>
    /// Returns a string representation of the fragment options.
    /// This is meant to be used when passing options to OpenSCAD objects as arguments.
    /// </summary>
    /// <returns>A string containing the fragment option if set; otherwise, an empty string.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        if (Fn.HasValue)
        {
            sb.Append($", $fn = {Fn.Value}");
        }

        return sb.ToString();
    }

    /// <summary>
    /// Writes the fragment option to the specified <see cref="StringWriter"/>.
    /// This is meant to write root-level options outside of object definitions.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    public readonly void Write(StringWriter w)
    {
        if (!Fn.HasValue)
            return;
        w.WriteLine($"$fn = {Fn};");
    }

    /// <summary>
    /// Creates a new <see cref="FragmentOptions"/> instance from the specified fragment count.
    /// </summary>
    /// <param name="fn">The number of fragments ($fn) to use.</param>
    /// <returns>A new <see cref="FragmentOptions"/> instance.</returns>
    public static FragmentOptions FromFn(uint fn)
    {
        return new FragmentOptions(fn);
    }

    /// <summary>
    /// Gets a <see cref="FragmentOptions"/> instance representing high resolution ($fn = 100).
    /// </summary>
    public static readonly FragmentOptions HighRes = new(100);

    /// <summary>
    /// Gets a <see cref="FragmentOptions"/> instance representing medium resolution ($fn = 40).
    /// </summary>
    public static readonly FragmentOptions MidRes = new(40);
}