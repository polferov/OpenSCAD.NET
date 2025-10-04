using OpenSCAD.NET.Units;
using OpenSCAD.NET.Boolean;

namespace OpenSCAD.NET.Common;

/// <summary>
/// Abstract base class for dimensional objects that can contain child objects.
/// Provides common logic for writing object representations with children.
/// Essentially all objects of the form:
/// <code>
/// // OpenSCAD representation:
/// ${Name}(${...args}){
///    ${...children}
/// };
/// </code>
///
/// Example subclasses include boolean operations like <see cref="Difference{TUnit}"/>,
/// </summary>
public abstract class ObjectWithChildren<TUnit> : IDimensionalObject<TUnit>
    where TUnit : IDimensionalUnit
{
    /// <summary>
    /// Gets the name of the object, used in output representation.
    /// </summary>
    /// <code>
    /// // OpenSCAD representation example:
    /// ${Name}(${...args}){
    ///    ${...Children}
    /// };
    /// </code>
    public abstract string Name { get; }

    /// <summary>
    /// Gets the children of the object.
    /// </summary>
    /// <code>
    /// // OpenSCAD representation example:
    /// ${Name}(${...args}){
    ///    ${...Children}
    /// };
    /// </code>
    public abstract IDimensionalObject<TUnit>[] Children { get; }

    /// <summary>
    /// Writes the arguments for this object to the provided <see cref="StringWriter"/>.
    /// Writes the part between the parentheses in the OpenSCAD representation.
    /// If there are no arguments, this method should not write anything.
    /// <code>
    /// // OpenSCAD representation example:
    /// ${Name}(${...args}){
    ///    ${...Children}
    /// };
    /// </code>
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write arguments to.</param>
    public abstract void WriteArgs(StringWriter w);

    /// <summary>
    /// Writes the body (children) of this object to the provided <see cref="StringWriter"/> with indentation.
    /// Not including the opening and closing braces.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
    private protected virtual void WriteBody(StringWriter w, int idt)
    {
        foreach (var child in Children)
        {
            child.Write(w, idt + 1);
        }
    }

    /// <summary>
    /// Writes the full representation of this object, including its arguments and children, to the provided <see cref="StringWriter"/>.
    /// </summary>
    /// <param name="w">The <see cref="StringWriter"/> to write to.</param>
    /// <param name="idt">The indentation level.</param>
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