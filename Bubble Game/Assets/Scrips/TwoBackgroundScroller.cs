using UnityEngine;

public class TwoBackgroundScroller : MonoBehaviour
{
    [Header("Background References")]
    public Transform background1; 
    public Transform background2;

    [Header("Scroll Settings")]
    public float scrollSpeed = 2f;
    // The full height of each background in world units
    // e.g., if each sprite is 10 units tall in your scene, set this to 10
    public float backgroundHeight = 10f;

    void Update()
    {
        // Move both backgrounds downward
        background1.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        background2.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // If background1 goes fully below a certain point, jump it above background2
        if (background1.position.y < -backgroundHeight)
        {
            RepositionBackground(background1, background2);
        }

        // Similarly, if background2 goes fully below, jump it above background1
        if (background2.position.y < -backgroundHeight)
        {
            RepositionBackground(background2, background1);
        }
    }

    private void RepositionBackground(Transform bgToMove, Transform otherBG)
    {
        // Move the backgroundToMove up by 2 * backgroundHeight
        // so it appears seamlessly above the other
        bgToMove.position = new Vector3(
            bgToMove.position.x, 
            otherBG.position.y + backgroundHeight, 
            bgToMove.position.z
        );
    }
}
