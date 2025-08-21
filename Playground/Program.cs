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

var grid = Grid.DiagonalSquareHoleGrid(5, 10, 10.mm(), 1.mm(), SquareFactory);

var sw = new StringWriter();
grid.Write(sw, 0);
var scad = sw.ToString();
File.WriteAllText("./out.scad", scad);
return;

IDimensionalObject<Unit2D> SquareFactory(Unit sideLength)
{
    var circle = Circle.FromDiameter(sideLength)
        .Translate(sideLength.ToUnit2D() / 2);
    return circle;
}
