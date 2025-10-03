using System.Collections;
using OpenSCAD.NET.Common;

namespace OpenSCAD.NET.CodeConsistency;

public class DimensionalObjectSource : IEnumerable<object[]>
{
    private static readonly Lazy<List<object[]>> Types = new(Factory);

    private static List<object[]> Factory()
    {
        var doType = typeof(IDimensionalObject);
        return doType.Assembly.DefinedTypes
            .Where(t => !t.IsAbstract && t.IsAssignableTo(doType))
            .Select(t => new object[] { t })
            .ToList();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        return Types.Value.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}