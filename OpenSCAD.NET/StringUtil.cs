namespace OpenSCAD.NET;

/// <summary>
/// Provides utility methods for string formatting and manipulation.
/// </summary>
public static class StringUtil
{
    /// <summary>
    /// Returns a string consisting of spaces for indentation.
    /// </summary>
    /// <param name="level">The indentation level (number of 4-space blocks).</param>
    /// <returns>A string with <paramref name="level"/> * 4 spaces.</returns>
    public static string Indent(int level)
    {
        return new string(' ', level * 4);
    }

    /// <summary>
    /// Converts a boolean value to its lowercase string representation ("true" or "false").
    /// </summary>
    /// <param name="value">The boolean value.</param>
    /// <returns>"true" if <paramref name="value"/> is true; otherwise, "false".</returns>
    public static string ToLowerString(this bool value)
    {
        return value ? "true" : "false";
    }

    /// <summary>
    /// Writes indentation spaces to the specified <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="stringWriter">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="indentation">The indentation level (number of 4-space blocks).</param>
    public static void WriteIndentation(this StringWriter stringWriter, int indentation)
    {
        stringWriter.Write(Indent(indentation));
    }
}