namespace OpenSCAD.NET;

public interface I3DObject
{
    void Write(StringWriter w, int idt);
}