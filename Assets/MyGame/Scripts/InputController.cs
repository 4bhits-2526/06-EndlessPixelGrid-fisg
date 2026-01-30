using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {
    public PixelModel model;
    public Image[] inputImages;

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) TogglePixel(0);
        if (Input.GetKeyDown(KeyCode.A)) TogglePixel(1);
        if (Input.GetKeyDown(KeyCode.UpArrow)) TogglePixel(2);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) TogglePixel(3);
        if (Input.GetKeyDown(KeyCode.RightArrow)) TogglePixel(4);
        if (Input.GetKeyDown(KeyCode.DownArrow)) TogglePixel(5);
        if (Input.GetKeyDown(KeyCode.S)) TogglePixel(6);

        if (Input.GetKeyDown(KeyCode.D)) {
            PushInputLineIntoGrid();
        }
    }

    void TogglePixel(int index) {
        model.inputLine[index] = !model.inputLine[index];
        inputImages[index].color = model.inputLine[index] ? Color.white : Color.black;
    }

    void PushInputLineIntoGrid() {
        for (int row = 0; row < model.grid.GetLength(0) - 1; row++) {
            for (int col = 0; col < model.grid.GetLength(1); col++) {
                model.grid[row, col] = model.grid[row + 1, col];
            }
        }

        int lastRow = model.grid.GetLength(0) - 1;
        for (int col = 0; col < model.grid.GetLength(1); col++) {
            model.grid[lastRow, col] = model.inputLine[col];
        }

        for (int i = 0; i < model.inputLine.Length; i++) {
            model.inputLine[i] = false;
        }
    }
}
