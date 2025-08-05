using System.Diagnostics.SymbolStore;
using System.Reflection;
using OpenSCAD.NET.HotReload;

[assembly: System.Reflection.Metadata.MetadataUpdateHandler(typeof(HotReloader))]

namespace OpenSCAD.NET.HotReload;

public static class HotReloader
{
    private static bool _isFirstRun = true;
    private static string[] _args = null!;

    private static readonly Lazy<MethodInfo> Entrypoint = new(() =>
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly is null)
            throw new Exception("Could not determine entry assembly");

        var ep = entryAssembly.EntryPoint;
        if (ep is null)
            throw new Exception("Could not determine entry point");

        var parms = ep.GetParameters();
        if (parms.Length != 1)
            throw new Exception("Entrypoint does not take exactly one parameter");

        if (parms[0].ParameterType != typeof(string[]))
            throw new Exception("Parameter Type of entrypoint must be Main(string[] args)");

        return ep;
    });

    public static async ValueTask RunAsync(string[] args)
    {
        if (!_isFirstRun)
            return;
        _args = args;
        _isFirstRun = false;
        InvokeEntrypoint();


        while (true)
        {
            await Task.Delay(1000);
        }
    }

    private static void InvokeEntrypoint()
    {
        Entrypoint.Value.Invoke(null, [_args]);
    }

    private static void ClearCache(Type[]? updatedTypes)
    {
        // no op
    }

    private static void UpdateApplication(Type[]? updatedTypes)
    {
        InvokeEntrypoint();
    }
}