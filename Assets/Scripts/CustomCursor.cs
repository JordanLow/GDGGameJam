using UnityEngine;
using UnityEngine.InputSystem;  // If you're using the New Input System

public class CustomCursor : MonoBehaviour
{
    [SerializeField] Texture2D normalCursorTexture;   // Default cursor texture
    [SerializeField] Texture2D clickCursorTexture;    // Click/animated cursor texture
    private Vector2 cursorHotspot;  // Cursor hotspot (pivot point)

    private bool isClicking = false;

    void Start()
    {
		cursorHotspot = new Vector2(0, normalCursorTexture.height/2);
        // Set the default cursor at the start
        SetNormalCursor();
    }

    void Update()
    {
        // Check for left mouse click using Input System (new or old)
        if (buttonHeldDown())  // New Input System
        {
            // Set click animation cursor
            SetClickCursor();
            isClicking = true;
        }

        // When the mouse button is released, revert to the normal cursor
        if (Mouse.current.leftButton.wasReleasedThisFrame || Mouse.current.rightButton.wasReleasedThisFrame && isClicking)
        {
            SetNormalCursor();
            isClicking = false;
        }
    }
	
	bool buttonHeldDown() {
		return Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame;
	}

    // Set the default cursor
    void SetNormalCursor()
    {
        Cursor.SetCursor(normalCursorTexture, cursorHotspot, CursorMode.Auto);
    }

    // Set the click animation cursor
    void SetClickCursor()
    {
        Cursor.SetCursor(clickCursorTexture, cursorHotspot, CursorMode.Auto);
    }
}