namespace OpenSCAD.NET.Common;

public interface IHasFragmentOptions
{
    FragmentOptions FragmentOptions { get; set; }
}

public static class HasFragmentOptionsExtensions
{
    public static T WithFragmentOptions<T>(this T obj, FragmentOptions options) where T : IHasFragmentOptions
    {
        obj.FragmentOptions = options;
        return obj;
    }
}