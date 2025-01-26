using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ComicPanelController : MonoBehaviour
{
    [Header("References")]
    public Image[] panels;

    [Header("Settings")]
    public float fadeDuration = 1f;
    public float delayBetweenPanels = 1.5f;

    private Coroutine sequenceCoroutine;

    private void Start()
    {
        sequenceCoroutine = StartCoroutine(FadePanelsInSequence());
    }

    private IEnumerator FadePanelsInSequence()
    {
        foreach (Image panel in panels)
        {
            SetPanelAlpha(panel, 0f);
            yield return StartCoroutine(FadeInPanel(panel));
            yield return new WaitForSeconds(delayBetweenPanels);
        }
    }

    private IEnumerator FadeInPanel(Image panel)
    {
        float elapsedTime = 0f;
        Color color = panel.color;

        color.a = 0f;
        panel.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            color.a = alpha;
            panel.color = color;
            yield return null;
        }

        // Ensure full opacity at the end
        color.a = 1f;
        panel.color = color;
    }

    // Skip panels only
    public void SkipComic()
    {
        if (sequenceCoroutine != null)
        {
            StopCoroutine(sequenceCoroutine);
        }

        foreach (Image panel in panels)
        {
            SetPanelAlpha(panel, 1f);
        }
    }

    // Skip panels and load new scene
    public void SkipComicAndLoadGame(string sceneName)
    {
        // Stop fade sequence if still running
        if (sequenceCoroutine != null)
        {
            StopCoroutine(sequenceCoroutine);
        }

        // Make panels fully visible (optional step, if you want them visible before loading)
        foreach (Image panel in panels)
        {
            SetPanelAlpha(panel, 1f);
        }

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }

    private void SetPanelAlpha(Image panel, float alpha)
    {
        Color c = panel.color;
        c.a = alpha;
        panel.color = c;
    }
}
