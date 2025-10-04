using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using OpenSCAD.NET.HotReload;

[assembly: MetadataUpdateHandler(typeof(HotReloader))]

namespace OpenSCAD.NET.HotReload;

/// <summary>
/// Provides hot-reloading capabilities for the application.
/// </summary>
public static class HotReloader
{
    private static bool _processRunning;
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


    /// <summary>
    /// Runs the OpenSCAD previewer with the generated SCAD file.
    /// Closes the application when the previewer is closed.
    /// Closes the previewer when the application is closed.
    /// </summary>
    public static void RunPreviewer()
    {
        if (_processRunning)
            return;
        _processRunning = true;
        var p = new Process();
        p.StartInfo.FileName = "openscad";
        p.StartInfo.ArgumentList.Add("out.scad");
        p.Start();
        Task.Run(async () =>
        {
            await p.WaitForExitAsync();
            Environment.Exit(0);
        });
    }

    /// <summary>
    /// Runs a loop that keeps the application alive and handles hot-reloading.
    /// Reruns the model generation (the whole program, actually) on hot-reload.
    /// </summary>
    /// <param name="args">arguments passed to the program</param>
    public static void Run(string[] args)
    {
        if (!_isFirstRun)
            return;
        _args = args;
        _isFirstRun = false;
        InvokeEntrypoint();


        while (true)
        {
            Thread.Sleep(1000);
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