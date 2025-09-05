using OpenSCAD.NET.Boolean;
using OpenSCAD.NET.Common;
using OpenSCAD.NET.Primitives2D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Extended2D;

public class Grid : IDimensionalObject<Unit2D>
{
    public int CellsX { get; }
    public int CellsY { get; }
    public int ExtraCellsX { get; }
    public int ExtraCellsY { get; }
    public Unit2D Spacing { get; }
    public Unit2D LineWidth { get; }
    public Unit2D Border { get; }
    public IDimensionalObject<Unit2D> GridCutout { get; }

    private Grid(int cellsX, int cellsY, int extraCellsX, int extraCellsY, Unit2D spacing, Unit2D lineWidth,
        Unit2D border,
        IDimensionalObject<Unit2D> gridCutout)
    {
        CellsX = cellsX;
        CellsY = cellsY;
        ExtraCellsX = extraCellsX;
        ExtraCellsY = extraCellsY;
        Spacing = spacing;
        LineWidth = lineWidth;
        Border = border;
        GridCutout = gridCutout;
    }

    public void WriteDiff(StringWriter w, int idt)
    {
        w.WriteIndentation(idt);
        w.WriteLine($"for (x = [0 : {CellsX + ExtraCellsX - 1}]) {{");
        w.WriteIndentation(idt + 1);
        w.WriteLine($"for (y = [0 : {CellsY + ExtraCellsX - 1}]) {{");
        w.WriteIndentation(idt + 2);
        w.WriteLine(
            $"translate([{Border.X} / 2 + ({Spacing.X} + {LineWidth.X}) * x, {Border.Y} / 2 + ({Spacing.Y} + {LineWidth.Y}) * y]) {{");
        GridCutout.Write(w, idt + 3);
        w.WriteIndentation(idt + 2);
        w.WriteLine("}");
        w.WriteIndentation(idt + 1);
        w.WriteLine("}");
        w.WriteIndentation(idt);
        w.WriteLine("}");
    }

    public void Write(StringWriter w, int idt)
    {
        var sizeX = (Spacing.X + LineWidth.X) * CellsX;
        var sizeY = (Spacing.Y + LineWidth.Y) * CellsY;
        var size = new Unit2D(sizeX, sizeY);
        w.WriteIndentation(idt);
        w.WriteLine("difference() {");
        w.WriteIndentation(idt + 1);
        w.WriteLine($"square({size});");
        WriteDiff(w, idt + 1);
        w.WriteIndentation(idt);
        w.WriteLine("}");
    }

    public static Grid FromParameters(int cellsX, int cellsY, int extraCellsX, int extraCellsY, Unit2D spacing,
        Unit2D lineWidth, Unit2D border,
        IDimensionalObject<Unit2D> gridCutout)
        => new Grid(cellsX, cellsY, extraCellsX, extraCellsY, spacing, lineWidth, border, gridCutout);

    public static Grid SquareHoleGrid(int cellsX, int cellsY, Unit sideLength, Unit lineWidth)
    {
        var hole = Square.FromSideLength(sideLength);
        return new Grid(cellsX, cellsY, 0, 0, (sideLength, sideLength), (lineWidth, lineWidth),
            (lineWidth / 2, lineWidth / 2), hole);
    }

    public static Square DefaultSquareFactory(Unit sideLength)
    {
        return Square.FromSideLength(sideLength);
    }

    public static Grid DiagonalSquareHoleGrid(int cellsX, int cellsY, Unit diagonalLength, Unit lineWidth,
        bool lineWidthIsDiagonal,
        bool startCenter)
        => DiagonalSquareHoleGrid(cellsX, cellsY, diagonalLength, lineWidth, lineWidthIsDiagonal, startCenter,
            DefaultSquareFactory);

    public static Grid DiagonalSquareHoleGrid(int cellsX, int cellsY, Unit diagonalLength, Unit lineWidth,
        bool lineWidthIsDiagonal, bool startCenter,
        Func<Unit, IDimensionalObject<Unit2D>> squareFactory)
    {
        var sideLength = diagonalLength / (decimal)Math.Sqrt(2);
        var square = squareFactory(sideLength)
            .RotateZ(45.deg());

        if (lineWidthIsDiagonal)
            lineWidth = lineWidth * (decimal)Math.Sqrt(2);

        var secondSquare = square
            .Translate(((diagonalLength + lineWidth) / 2, (diagonalLength + lineWidth) / 2));

        var hole = square.Union(secondSquare)
            .TranslateY((diagonalLength + lineWidth / 2) * -1);


        if (startCenter)
            hole = hole.TranslateX((diagonalLength + lineWidth) * -0.5m);


        return new Grid(cellsX, cellsY, 1, 1, (diagonalLength, diagonalLength), (lineWidth, lineWidth), (0, 0), hole);
    }
}