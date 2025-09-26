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


// values from playing around with https://www.omnicalculator.com/math/truncated-cone-volume
// trying to get around 11cm^3
var spoonRad = 18.mm();
var spoonRadBottom = 12.mm();
var spoonDepth = 15.mm();
var handleWidth = 10.mm();
var handleLength = 50.mm();
var thickness = 1.2.mm();


var cupInner = Cylinder2R
    .FromRadiiAndHeight(spoonRad, spoonRadBottom, spoonDepth);

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
// FragmentOptions.MidRes.Write(sw);
FragmentOptions.HighRes.Write(sw);
model.Write(sw, 0);
var scad = sw.ToString();
File.WriteAllText("./out.scad", scad);