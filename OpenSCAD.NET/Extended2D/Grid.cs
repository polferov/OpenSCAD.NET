using OpenSCAD.NET.Boolean;
using OpenSCAD.NET.Common;
using OpenSCAD.NET.Primitives2D;
using OpenSCAD.NET.Transformations;
using OpenSCAD.NET.Units;

namespace OpenSCAD.NET.Extended2D;

/// <summary>
/// Represents a 2D grid structure with customizable cell size, spacing, border, and cutout shape.
/// Provides methods for generating grid patterns with various hole configurations.
/// </summary>
public class Grid : IDimensionalObject<Unit2D>
{
    /// <summary>
    /// Gets the number of cells in the X direction.
    /// </summary>
    public int CellsX { get; }

    /// <summary>
    /// Gets the number of cells in the Y direction.
    /// </summary>
    public int CellsY { get; }

    /// <summary>
    /// Gets the number of extra cells in the X direction (for offset or padding).
    /// </summary>
    public int ExtraCellsX { get; }

    /// <summary>
    /// Gets the number of extra cells in the Y direction (for offset or padding).
    /// </summary>
    public int ExtraCellsY { get; }

    /// <summary>
    /// Gets the spacing between grid cells.
    /// </summary>
    public Unit2D Spacing { get; }

    /// <summary>
    /// Gets the Space that one cell occupies, excluding the line width.
    /// </summary>
    public Unit2D LineWidth { get; }

    /// <summary>
    /// Gets the border size around the grid.
    /// The components of this vector are the X any Y thicknesses of the border.
    /// </summary>
    public Unit2D Border { get; }

    /// <summary>
    /// Gets the cutout shape used for each grid cell.
    /// This is the shape that is repeatedly subtracted from the baseplate to create the grid pattern.
    /// </summary>
    public IDimensionalObject<Unit2D> GridCutout { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Grid"/> class with the specified parameters.
    /// </summary>
    /// <param name="cellsX">Number of cells in the X direction.</param>
    /// <param name="cellsY">Number of cells in the Y direction.</param>
    /// <param name="extraCellsX">Number of extra cells in the X direction.</param>
    /// <param name="extraCellsY">Number of extra cells in the Y direction.</param>
    /// <param name="spacing">Size of a cell without lineWidth</param>
    /// <param name="lineWidth">Width of grid lines.</param>
    /// <param name="border">Border size around the grid.</param>
    /// <param name="gridCutout">Cutout shape for each cell.</param>
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

    private void WriteDiff(StringWriter w, int idt)
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

    /// <inheritdoc />
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

    /// <summary>
    /// Creates a new <see cref="Grid"/> instance from the specified parameters.
    /// </summary>
    /// <param name="cellsX">Number of cells in the X direction.</param>
    /// <param name="cellsY">Number of cells in the Y direction.</param>
    /// <param name="extraCellsX">Number of extra cells in the X direction.</param>
    /// <param name="extraCellsY">Number of extra cells in the Y direction.</param>
    /// <param name="spacing">Size of a cell without lineWidth.</param>
    /// <param name="lineWidth">Width of grid lines.</param>
    /// <param name="border">Border size around the grid.</param>
    /// <param name="gridCutout">Cutout shape for each cell.</param>
    /// <returns>A new <see cref="Grid"/> instance.</returns>
    public static Grid FromParameters(int cellsX, int cellsY, int extraCellsX, int extraCellsY, Unit2D spacing,
        Unit2D lineWidth, Unit2D border,
        IDimensionalObject<Unit2D> gridCutout)
        => new Grid(cellsX, cellsY, extraCellsX, extraCellsY, spacing, lineWidth, border, gridCutout);

    /// <summary>
    /// Creates a grid with square holes of the specified side length and line width.
    /// </summary>
    /// <param name="cellsX">Number of cells in the X direction.</param>
    /// <param name="cellsY">Number of cells in the Y direction.</param>
    /// <param name="sideLength">Side length of each square hole.</param>
    /// <param name="lineWidth">Width of grid lines.</param>
    /// <returns>A new <see cref="Grid"/> instance with square holes.</returns>
    public static Grid SquareHoleGrid(int cellsX, int cellsY, Unit sideLength, Unit lineWidth)
    {
        var hole = Square.FromSideLength(sideLength);
        return new Grid(cellsX, cellsY, 0, 0, (sideLength, sideLength), (lineWidth, lineWidth),
            (lineWidth / 2, lineWidth / 2), hole);
    }

    /// <summary>
    /// Default factory for creating a square with the specified side length.
    /// </summary>
    /// <param name="sideLength">Side length of the square.</param>
    /// <returns>A new <see cref="Square"/> instance.</returns>
    public static Square DefaultSquareFactory(Unit sideLength)
    {
        return Square.FromSideLength(sideLength);
    }

    /// <summary>
    /// Creates a grid with diagonal square holes, using the specified diagonal length and line width.
    /// </summary>
    /// <param name="cellsX">Number of cells in the X direction.</param>
    /// <param name="cellsY">Number of cells in the Y direction.</param>
    /// <param name="diagonalLength">Diagonal length of each square hole.</param>
    /// <param name="lineWidth">Width of grid lines.</param>
    /// <param name="lineWidthIsDiagonal">Whether the line width is measured along the diagonal.</param>
    /// <param name="startCenter">Whether to start the grid centered.</param>
    /// <returns>A new <see cref="Grid"/> instance with diagonal square holes.</returns>
    public static Grid DiagonalSquareHoleGrid(int cellsX, int cellsY, Unit diagonalLength, Unit lineWidth,
        bool lineWidthIsDiagonal,
        bool startCenter)
        => DiagonalSquareHoleGrid(cellsX, cellsY, diagonalLength, lineWidth, lineWidthIsDiagonal, startCenter,
            DefaultSquareFactory);

    /// <summary>
    /// Creates a grid with diagonal square holes, using a custom square factory.
    /// </summary>
    /// <param name="cellsX">Number of cells in the X direction.</param>
    /// <param name="cellsY">Number of cells in the Y direction.</param>
    /// <param name="diagonalLength">Diagonal length of each square hole.</param>
    /// <param name="lineWidth">Width of grid lines.</param>
    /// <param name="lineWidthIsDiagonal">Whether the line width is measured along the diagonal.</param>
    /// <param name="startCenter">Whether to start the grid centered.</param>
    /// <param name="squareFactory">Factory function for creating the square cutout.</param>
    /// <returns>A new <see cref="Grid"/> instance with diagonal square holes.</returns>
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