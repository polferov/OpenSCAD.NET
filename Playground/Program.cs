using OpenSCAD.NET.HotReload;
using OpenSCAD.NET.Primitives3D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

await HotReloader.RunAsync(args);

var cube = Cube.WithSideLength(10.mm())
    .TranslateX(10.mm())
    .RotateX(6.deg())
    .TranslateX(10.mm());


var sw = new StringWriter();
cube.Write(sw, 0);

Console.WriteLine(sw.ToString());