using OpenSCAD.NET.Boolean;
using OpenSCAD.NET.Common;
using OpenSCAD.NET.Extended2D;
using OpenSCAD.NET.HotReload;
using OpenSCAD.NET.Primitives2D;
using OpenSCAD.NET.Primitives3D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

await HotReloader.RunAsync(args);
HotReloader.RunPreviewer();

var thickness = 5;

var polygon = Polygon.FromPoints((0, 0), (50, 0), (50, 20),
        (50 + thickness, 20), (50 + thickness, -thickness), (-thickness, -thickness),
        (-thickness, 60), (0, 60))
    .Minkowski(Circle.FromRadius(5.mm()).WithFragmentOptions(FragmentOptions.HighRes))
    .Extrude(15.mm());

var grid = Grid.DiagonalSquareHoleGrid(5, 10, 10.mm(), 1.mm());

var sw = new StringWriter();
grid.Write(sw, 0);
var scad = sw.ToString();
File.WriteAllText("./out.scad", scad);