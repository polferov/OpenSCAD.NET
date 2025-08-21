using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Common;

public interface IDimensionalObject
{
    void Write(StringWriter w, int idt);
}

public interface IDimensionalObject<TUnit> : IDimensionalObject
    where TUnit : IDimensionalUnit;