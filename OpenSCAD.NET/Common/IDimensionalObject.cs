using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Common;

public interface IDimensionalObject<TUnit>
    where TUnit : IDimensionalUnit
{
    void Write(StringWriter w, int idt);
}