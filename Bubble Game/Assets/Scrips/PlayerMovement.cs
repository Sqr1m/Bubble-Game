using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения
    public Vector2 horizontalBounds = new Vector2(-8f, 8f); // Ограничения по ширине
    public Vector2 verticalBounds = new Vector2(-4f, 4f); // Ограничения по высоте

    private Animator animator; // Ссылка на Animator
    private Vector3 originalScale; // Для поворота персонажа

    void Start()
    {
        animator = GetComponent<Animator>(); // Получаем компонент Animator
        originalScale = transform.localScale; // Запоминаем изначальный масштаб
    }

    void Update()
    {
        // Получаем входные данные
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Рассчитываем новое положение
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime;

        // Ограничиваем движение
        newPosition.x = Mathf.Clamp(newPosition.x, horizontalBounds.x, horizontalBounds.y);
        newPosition.y = Mathf.Clamp(newPosition.y, verticalBounds.x, verticalBounds.y);
        transform.position = newPosition;

        // Передаем значения в Animator
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);

        // Поворот персонажа в зависимости от направления
        if (moveX > 0)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
    }
}
