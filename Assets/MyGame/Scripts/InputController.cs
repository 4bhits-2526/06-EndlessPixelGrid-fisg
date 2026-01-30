using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {
    public Image[] inputImages;
    public bool[] inputLine = new bool[7];
    public bool[,] grid = new bool[10, 7];
    public Image[,] gridImages;
    public GameObject gridContainer;

    private void Awake() {
        FillGridImagesFromChildren();
        RenderAll();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.W)) TogglePixel(0);
        if (Input.GetKeyDown(KeyCode.A)) TogglePixel(1);
        if (Input.GetKeyDown(KeyCode.UpArrow)) TogglePixel(2);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) TogglePixel(3);
        if (Input.GetKeyDown(KeyCode.RightArrow)) TogglePixel(4);
        if (Input.GetKeyDown(KeyCode.DownArrow)) TogglePixel(5);
        if (Input.GetKeyDown(KeyCode.S)) TogglePixel(6);

        if (Input.GetKeyDown(KeyCode.D)) {
            PushInputLineIntoGrid();
            RenderAll();
        }

        if (Input.GetKeyDown(KeyCode.G)) {
            ResetGridAndInput();
            RenderAll();
        }
    }

    void TogglePixel(int index) {
        inputLine[index] = !inputLine[index];
        RenderInputLine();
    }

    void PushInputLineIntoGrid() {
        for (int row = 0; row < grid.GetLength(0) - 1; row++) {
            for (int col = 0; col < grid.GetLength(1); col++) {
                grid[row, col] = grid[row + 1, col];
            }
        }

        int lastRow = grid.GetLength(0) - 1;
        for (int col = 0; col < grid.GetLength(1); col++) {
            grid[lastRow, col] = inputLine[col];
        }

        for (int i = 0; i < inputLine.Length; i++) {
            inputLine[i] = false;
        }
    }

    void ResetGridAndInput() {
        for (int r = 0; r < grid.GetLength(0); r++) {
            for (int c = 0; c < grid.GetLength(1); c++) {
                grid[r, c] = false;
            }
        }

        for (int i = 0; i < inputLine.Length; i++) {
            inputLine[i] = false;
        }
    }

    public void RenderInputLine() {
        for (int i = 0; i < inputImages.Length; i++) {
            inputImages[i].color = inputLine[i] ? Color.white : Color.black;
        }
    }

    public void RenderGrid() {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (gridImages[r, c] != null)
                    gridImages[r, c].color = grid[r, c] ? Color.white : Color.black;
            }
        }
    }

    void FillGridImagesFromChildren() {
        int rows = 10;
        int cols = 7;
        gridImages = new Image[rows, cols];

        Image[] childrenImages = gridContainer.GetComponentsInChildren<Image>();

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                int index = r * cols + c;
                if (index < childrenImages.Length)
                    gridImages[r, c] = childrenImages[index];
                else
                    Debug.LogError("Nicht genug Children-Images für das Raster!");
            }
        }
    }

    public void RenderAll() {
        RenderInputLine();
        RenderGrid();
    }
}
