using OpenSCAD.NET.Primitives3D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

var cube = new Cube(5.3.mm())
    .TranslateX(5.mm())
    .RotateX(5.deg());


var sw = new StringWriter();
cube.Write(sw, 0);

Console.WriteLine(sw.ToString());