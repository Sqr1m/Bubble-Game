using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{
    [Header("Assign Backgrounds Here")]
    public GameObject[] backgrounds;      // All the background GameObjects
    [Header("Switch Interval (seconds)")]
    public float switchInterval = 5f;     // How long each background stays visible

    private int currentIndex = 0;
    private bool keepSwitching = true;    // Controls whether we keep cycling

    void Start()
    {
        // Make sure only the first background is active at the start
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == 0);
        }

        // Begin automatic switching
        StartCoroutine(AutoSwitchLoop());
    }

    private IEnumerator AutoSwitchLoop()
    {
        // Keep cycling backgrounds until we stop
        while (keepSwitching)
        {
            // Wait for the designated interval
            yield return new WaitForSeconds(switchInterval);

            // Switch to the next background
            SwitchToNextBackground();
        }
    }

    private void SwitchToNextBackground()
    {
        // Turn off the current background
        backgrounds[currentIndex].SetActive(false);

        // Move to the next index
        currentIndex++;
        if (currentIndex >= backgrounds.Length)
            currentIndex = 0;  // Loop back to the start if we exceed array length

        // Turn on the new background
        backgrounds[currentIndex].SetActive(true);
    }

    // Call this method from another script/event when the player wins or loses.
    public void StopSwitching()
    {
        keepSwitching = false;
    }
}
