using OpenSCAD.NET.Primitives3D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

var cube = Cube.WithSideLength(10.mm())
    .TranslateX(10.mm())
    .RotateX(10.deg());


var sw = new StringWriter();
cube.Write(sw, 0);

Console.WriteLine(sw.ToString());