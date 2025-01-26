using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] bubbles;  // Ссылки на иконки пузырей
    public Sprite fullBubble;  // Спрайт полного пузыря
    public Sprite emptyBubble; // Спрайт пустого пузыря

    private int currentHealth;
    private const int maxHealth = 3;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < bubbles.Length; i++)
        {
            if (i < currentHealth)
                bubbles[i].sprite = fullBubble;
            else
                bubbles[i].sprite = emptyBubble;
        }
    }
}
