using OpenSCAD.NET.Boolean;
using OpenSCAD.NET.Common;
using OpenSCAD.NET.Extended2D;
using OpenSCAD.NET.HotReload;
using OpenSCAD.NET.Primitives2D;
using OpenSCAD.NET.Primitives3D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

// ReSharper disable InconsistentNaming

HotReloader.Run(args);
HotReloader.RunPreviewer();

var sideLength = 15.mm();
var offsetZ = 1.5.mm();
var ptfeHoleDiam = 5.5m.mm();
var screwHoleDiam = 5.5.mm();
var screwHoleDepth = 3.mm();
var screwHeadDiam = 10.mm();

var cube = Cube.FromSideLength(sideLength, center: true)
    .TranslateZ(offsetZ);

var ptfeMount = Cylinder1R.FromDiameterAndHeight(ptfeHoleDiam, sideLength + offsetZ * 2 + 1, center: true);

var screwHole = Cylinder1R.FromDiameterAndHeight(screwHoleDiam, sideLength + 1, center: true);
var screwHeadCutout = Cylinder1R.FromDiameterAndHeight(screwHeadDiam, sideLength, center: false)
    .TranslateZ(-sideLength / 2 + screwHoleDepth);
var screwCutout = screwHole.Union(screwHeadCutout)
    .RotateY(90.deg());

var model = cube.Subtract(ptfeMount, screwCutout);


var sw = new StringWriter();
// FragmentOptions.MidRes.Write(sw);
FragmentOptions.HighRes.Write(sw);
model.Write(sw, 0);
var scad = sw.ToString();
File.WriteAllText("./out.scad", scad);