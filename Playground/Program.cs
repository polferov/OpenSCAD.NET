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

var spoonDiam = 30.mm();
var spoonDiamBottom = 20.mm();
var spoonDepth = 10.mm();
var handleWidth = 10.mm();
var handleLength = 50.mm();
var thickness = 3.mm();


var cupInner = Cylinder2R
    .FromDiametersAndHeight(spoonDiam, spoonDiamBottom, spoonDepth);

var cup = cupInner
    .Minkowski(Sphere.FromRadius(thickness))
    .Intersect(Cylinder1R.FromDiameterAndHeight(100.mm(), 100.mm()));

var spoonBase = cup.Intersect(Cylinder1R.FromDiameterAndHeight(100.mm(), thickness))
    .Hull(
        Circle.FromDiameter(handleWidth).TranslateX(handleLength)
            .Extrude(thickness)
    );


var model = spoonBase.Union(cup).Subtract(cupInner.TranslateZ(-0.01m.mm()));
var sw = new StringWriter();
FragmentOptions.MidRes.Write(sw);
model.Write(sw, 0);
var scad = sw.ToString();
File.WriteAllText("./out.scad", scad);