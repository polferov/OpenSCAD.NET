using OpenSCAD.NET.Primitives3D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

var cube = Cube.WithSideLength(5.mm())
    .TranslateX(5.mm())
    .RotateX(5.deg());


var sw = new StringWriter();
cube.Write(sw, 0);

Console.WriteLine(sw.ToString());