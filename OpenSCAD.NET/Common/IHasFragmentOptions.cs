namespace OpenSCAD.NET.Common;

/// <summary>
/// Represents an object that has fragment options.
/// </summary>
/// <typeparam name="TSelf">Type of self</typeparam>
public interface IHasFragmentOptions<TSelf>
where TSelf : IHasFragmentOptions<TSelf>, IDimensionalObject
{
    /// <summary>
    /// Gets the fragment options for the object.
    /// </summary>
    public FragmentOptions FragmentOptions { get; }
    /// <summary>
    /// Returns a new instance of <typeparamref name="TSelf"/> that is identical to this instance,
    /// but with the specified fragment options.
    /// </summary>
    /// <param name="options">The fragment options to used.</param>
    /// <returns>A new instance of the object with the specified fragment options.</returns>
    TSelf WithFragmentOptions(FragmentOptions options);
        
}