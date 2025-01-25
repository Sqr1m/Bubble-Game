using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // Scrolling speed (units per second)
    public float scrollSpeed = 2f;

    // The vertical distance at which the background resets
    public float resetY = -10f;

    // The Y-position you want the background to jump back to after reset
    public float startY = 10f;

    void Update()
    {
        // Move the background down (negative Y) each frame
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // If it goes below resetY, jump it back to startY to create a continuous loop
        if (transform.position.y <= resetY)
        {
            // Keep the same x, jump y up to startY
            transform.position = new Vector2(transform.position.x, startY);
        }
    }
}
