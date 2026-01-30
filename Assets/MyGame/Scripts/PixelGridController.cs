using UnityEngine;
using UnityEngine.UI;

public class PixelGridController : MonoBehaviour {
    // UI-Referenzen (im Inspector setzen!)
    [SerializeField] private Image[] inputImages;

    // Datenmodell
    private bool[] inputLine = new bool[7];

    void Start() {
        RenderInputLine();
    }

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ToggleInput(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ToggleInput(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ToggleInput(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ToggleInput(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) ToggleInput(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) ToggleInput(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) ToggleInput(6);
    }

    void ToggleInput(int index) {
        inputLine[index] = !inputLine[index];
        RenderInputLine();
    }

    void RenderInputLine() {
        for (int i = 0; i < 7; i++)
            inputImages[i].color = inputLine[i] ? Color.white : Color.black;
    }
}