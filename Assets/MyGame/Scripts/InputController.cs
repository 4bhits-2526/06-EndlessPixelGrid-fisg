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
    }

    void TogglePixel(int index) {
        model.inputLine[index] = !model.inputLine[index];
        inputImages[index].color = model.inputLine[index] ? Color.white : Color.black;
    }
}
