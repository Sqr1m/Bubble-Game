using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Скорость движения персонажа
    private Animator animator; // Ссылка на компонент Animator
    private Vector2 movement; // Вектор для хранения ввода пользователя

    // Границы области перемещения
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -2.5f;
    public float maxY = 2.5f;

    void Start()
    {
        // Получаем компонент Animator, прикрепленный к объекту
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Получаем ввод пользователя по осям Horizontal и Vertical
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Нормализуем вектор движения, чтобы скорость была постоянной
        movement = movement.normalized;

        // Передаем значения в Animator для переключения анимаций
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("isMoving", movement.sqrMagnitude > 0);
    }

    void FixedUpdate()
    {
        // Перемещаем персонажа
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = currentPosition + movement * speed * Time.fixedDeltaTime;

        // Ограничиваем новую позицию заданными границами
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Применяем новую позицию к персонажу
        transform.position = newPosition;
    }
}
