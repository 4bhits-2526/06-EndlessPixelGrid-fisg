public class PixelGridModel {
    public bool[,] grid = new bool[10, 7];
    public bool[] inputLine = new bool[7];

    public void ClearInput() {
        for (int i = 0; i < 7; i++)
            inputLine[i] = false;
    }

    public void ClearGrid() {
        for (int r = 0; r < 10; r++)
            for (int c = 0; c < 7; c++)
                grid[r, c] = false;

        ClearInput();
    }
}