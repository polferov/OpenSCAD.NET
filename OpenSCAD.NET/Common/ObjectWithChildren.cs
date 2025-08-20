namespace OpenSCAD.NET.Common;

public abstract class ObjectWithChildren<TChild> : IDimensionalObject
    where TChild : IDimensionalObject
{
    public abstract string Name { get; }
    public abstract TChild[] Children { get; }
    public abstract void WriteArgs(StringWriter w);


    private protected virtual void WriteBody(StringWriter w, int idt)
    {
        foreach (var child in Children)
        {
            child.Write(w, idt + 1);
        }
    }


    public void Write(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.Write($"{Name}(");
        WriteArgs(w);
        if (Children.Length != 1)
        {
            w.WriteLine(") {");
            WriteBody(w, idt);
            w.WriteIndentation(idt);
            w.WriteLine("}");
        }
        else
        {
            w.WriteLine(")");
            WriteBody(w, idt);
        }
    }
}