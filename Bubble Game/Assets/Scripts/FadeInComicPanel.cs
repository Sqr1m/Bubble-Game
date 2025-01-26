using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComicIntro : MonoBehaviour
{
    public Image[] panels; // Array to hold your comic panels
    public float fadeDuration = 1.5f; // Duration for each fade
    public float delayBetweenPanels = 1.0f; // Delay between fades

    private void Start()
    {
        StartCoroutine(PlayComicSequence());
    }

    private IEnumerator PlayComicSequence()
    {
        foreach (Image panel in panels)
        {
            // Ensure the panel starts transparent
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);

            // Fade in the panel
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, alpha);
                yield return null;
            }

            // Wait before showing the next panel
            yield return new WaitForSeconds(delayBetweenPanels);
        }
    }
}