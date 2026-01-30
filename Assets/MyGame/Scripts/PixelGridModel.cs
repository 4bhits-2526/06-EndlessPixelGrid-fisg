public class PixelGridModel {
    public bool[,] grid;
    public bool[] inputLine;

    public PixelGridModel() {
        grid = new bool[10, 7];
        inputLine = new bool[7];
    }

    public void ClearInputLine() {
        for (int i = 0; i < inputLine.Length; i++)
            inputLine[i] = false;
    }

    public void ClearGrid() {
        for (int r = 0; r < grid.GetLength(0); r++)
            for (int c = 0; c < grid.GetLength(1); c++)
                grid[r, c] = false;

        ClearInputLine();
    }
}