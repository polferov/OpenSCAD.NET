using OpenSCAD.NET.Boolean;
using OpenSCAD.NET.Common;
using OpenSCAD.NET.Extended2D;
using OpenSCAD.NET.HotReload;
using OpenSCAD.NET.Primitives2D;
using OpenSCAD.NET.Primitives3D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

// ReSharper disable InconsistentNaming

await HotReloader.RunAsync(args);
HotReloader.RunPreviewer();

var length = 90.mm();
var height = 60.mm();
var res = FragmentOptions.HighRes;
var ext = 5.mm();

var grid = Grid.DiagonalSquareHoleGrid(3, 2, 26.mm(), 4.mm(), false, true);

var x0y0 = Circle.FromRadius(1.5.mm())
    .WithFragmentOptions(res);
var x1y0 = x0y0.TranslateX(length);
var x0y1 = x0y0.TranslateY(height);
var x1y1 = x0y0.Translate(length, height);

var ex0y0 = x0y0.TranslateX(-ext);
var ex0y1 = x0y1.TranslateX(-ext);
var ex1y0 = x1y0.TranslateX(ext);
var ex1y1 = x1y1.TranslateX(ext);

var frame = x0y0.Hull(x0y1)
    .Union(x1y1.Hull(x1y0))
    .Union(ex0y1.Hull(ex1y1))
    .Union(ex1y0.Hull(ex0y0));

var gridOpeningForLoop = Square.FromSideLength(10.mm())
    .Translate(40.mm(), -10.mm())
    .RotateZ(45.deg())
    .TranslateY(13.mm());

var loopAnkerPoint = Circle.FromRadius(2.mm())
    .WithFragmentOptions(res)
    .Translate(35.mm(), 40.mm());

var loopAnkerPoint2 = Circle.FromRadius(3.mm())
    .WithFragmentOptions(res)
    .Translate(42.mm(), 33.mm());

var loopAnkerPoint3 = Circle.FromRadius(5.mm())
    .WithFragmentOptions(res)
    .Translate(45.mm(), 30.mm());


var loopAnkerPoint4 = Circle.FromRadius(1.mm())
    .WithFragmentOptions(res)
    .Translate(60.mm(), 15.mm());

var loopAnker = loopAnkerPoint.Hull(loopAnkerPoint2)
    .Union(loopAnkerPoint2.Hull(loopAnkerPoint3))
    .Union(loopAnkerPoint3.Hull(loopAnkerPoint4));

var model = frame.Union(grid.Subtract(gridOpeningForLoop)).Union(loopAnker).TranslateX(-length / 2);

// model = model.Union(model.RotateZ(180.deg()));

var model3d = model.Extrude(4.mm());

var sw = new StringWriter();
model3d.Write(sw, 0);
var scad = sw.ToString();
File.WriteAllText("./out.scad", scad);