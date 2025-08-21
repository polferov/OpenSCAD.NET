namespace OpenSCAD.NET.Common;

public interface IHasFragmentOptions<TSelf>
where TSelf : IHasFragmentOptions<TSelf>
{
    public FragmentOptions FragmentOptions { get; }
    TSelf WithFragmentOptions(FragmentOptions options);
        
}