using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    // Drag each background (child) into this array in the Inspector
    public GameObject[] backgrounds;

    private int currentIndex = 0;

    void Start()
    {
        // Make sure only the first background is active at the start
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == 0);
        }
    }

    // Example method to switch to the next background
    public void SwitchToNextBackground()
    {
        // Turn off the current
        backgrounds[currentIndex].SetActive(false);

        // Move to the next index (wrap around if needed)
        currentIndex++;
        if (currentIndex >= backgrounds.Length)
        {
            currentIndex = 0;
        }

        // Turn on the new one
        backgrounds[currentIndex].SetActive(true);
    }
}
