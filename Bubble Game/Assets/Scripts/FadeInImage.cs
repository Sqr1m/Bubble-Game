using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInImage : MonoBehaviour
{
    public Image image; // Drag your Image component here
    public float fadeDuration = 1f; // Duration of the fade-in effect

    private void Start()
    {
        // Optional: Start with the image fully transparent
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        // Start the fade-in automatically
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeTo(1f)); // Fade to fully opaque
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = image.color.a; // Current alpha value
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha is exactly the target alpha
        image.color = new Color(image.color.r, image.color.g, image.color.b, targetAlpha);
    }
}