using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SequentialFadeIn : MonoBehaviour
{
    public Image firstImage;   // Drag the first image here in the Inspector
    public Image secondImage;  // Drag the second image here in the Inspector
    public Button firstButton; // Drag the first button here in the Inspector
    public Button secondButton; // Drag the second button here in the Inspector
    public float fadeDuration = 1f; // Duration of each fade-in

    private void Start()
    {
        // Start with all elements fully transparent
        SetAlpha(firstImage, 0f);
        SetAlpha(secondImage, 0f);
        SetAlpha(firstButton.image, 0f);
        SetAlpha(secondButton.image, 0f);

        // Begin the sequence
        StartCoroutine(FadeSequence());
    }

    private IEnumerator FadeSequence()
    {
        // Fade in first image
        yield return StartCoroutine(FadeTo(firstImage, 1f));

        // Fade in second image
        yield return StartCoroutine(FadeTo(secondImage, 1f));

        // Fade in both buttons at the same time
        StartCoroutine(FadeTo(firstButton.image, 1f));
        yield return StartCoroutine(FadeTo(secondButton.image, 1f));
    }

    private IEnumerator FadeTo(Graphic graphic, float targetAlpha)
    {
        float startAlpha = graphic.color.a;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / fadeDuration);
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, newAlpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha is exactly the target alpha
        graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, targetAlpha);
    }

    private void SetAlpha(Graphic graphic, float alpha)
    {
        Color color = graphic.color;
        color.a = alpha;
        graphic.color = color;
    }
}