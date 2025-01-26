using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HealthManager healthManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DamageItem"))  // Враг или ловушка
        {
            healthManager.ChangeHealth(-1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("HealItem"))  // Лечебный предмет
        {
            healthManager.ChangeHealth(3);
            Destroy(other.gameObject);
        }
    }
}
