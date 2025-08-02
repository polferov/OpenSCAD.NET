namespace OpenSCAD.NET;

internal static class StringUtil
{
    public static string Indent(int level)
    {
        return new string(' ', level * 4);
    }

    public static string ToLowerString(this bool value)
    {
        return value ? "true" : "false";
    }

    public static void WriteIndentation(this StringWriter stringWriter, int indentation)
    {
        stringWriter.Write(Indent(indentation));
    }
}