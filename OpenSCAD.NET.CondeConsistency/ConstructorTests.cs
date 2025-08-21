using System.Reflection;

namespace OpenSCAD.NET.CondeConsistency;

public class ConstructorTests
{
    [Theory]
    [ClassData(typeof(DimensionalObjectSource))]
    public void DimensionalObjectsHaveExactlyOneNonPublicConstructor(Type t)
    {
        // Arrange
        var constructors = t.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

        // Act
        var count = constructors.Length;

        // Assert
        Assert.Equal(1, count);
    }

    [Theory]
    [ClassData(typeof(DimensionalObjectSource))]
    public void DimensionalObjectsShouldHaveNoPublicConstructor(Type t)
    {
        var constructors = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.Empty(constructors);
    }
}