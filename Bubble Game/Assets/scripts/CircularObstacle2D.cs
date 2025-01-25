using UnityEngine;

public class CircularObstacle2D : MonoBehaviour
{
    public float radius = 5f;        // Радиус движения (если используется круговое движение)
    public float orbitSpeed = 2f;   // Скорость вращения вокруг центра
    public float rotationSpeed = 100f; // Скорость вращения вокруг своей оси
    public Transform center;        // Центр вращения (опционально, если используется круговое движение)

    public float activeTime = 15f;  // Время, в течение которого объект видим
    public float inactiveTime = 20f; // Время, в течение которого объект невидим

    public Vector2 areaMin = new Vector2(-5f, -5f); // Минимальные границы области
    public Vector2 areaMax = new Vector2(5f, 5f);   // Максимальные границы области
    public float moveSpeed = 5f;     // Скорость перемещения к случайной точке

    private float angle;             // Текущий угол для кругового движения
    private float timer;             // Таймер
    private bool isVisible = true;   // Видим ли объект сейчас
    private SpriteRenderer spriteRenderer; // Компонент визуализации

    private Vector3 targetPosition;  // Текущая случайная цель
    private bool useRandomMovement = true; // Если true, используется случайное движение вместо кругового

    void Start()
    {
        // Получаем компонент SpriteRenderer для управления видимостью
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("Отсутствует компонент SpriteRenderer!");
            enabled = false;
            return;
        }

        // Устанавливаем начальное состояние
        timer = activeTime;

        // Устанавливаем первую случайную цель
        if (useRandomMovement)
        {
            SetRandomTarget();
        }
    }

    void Update()
    {
        if (isVisible)
        {
            // Если объект активен, выполняем движение
            if (useRandomMovement)
            {
                // Движение к случайной точке
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                // Если достигли цели, выбираем новую случайную точку
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    SetRandomTarget();
                }
            }
            else if (center != null)
            {
                // Круговое движение вокруг центра
                angle += orbitSpeed * Time.deltaTime;

                float x = center.position.x + radius * Mathf.Cos(angle);
                float y = center.position.y + radius * Mathf.Sin(angle);

                transform.position = new Vector3(x, y, transform.position.z);
            }

            // Вращение вокруг своей оси
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        // Обновляем таймер
        timer -= Time.deltaTime;

        if (isVisible)
        {
            // Если время видимости истекло
            if (timer <= 0f)
            {
                isVisible = false;              // Скрываем объект
                timer = inactiveTime;          // Переключаем на таймер неактивного состояния
                spriteRenderer.enabled = false; // Делаем объект невидимым
            }
        }
        else
        {
            // Если время невидимости истекло
            if (timer <= 0f)
            {
                isVisible = true;               // Показываем объект
                timer = activeTime;            // Переключаем на таймер активного состояния
                spriteRenderer.enabled = true; // Делаем объект видимым

                // Устанавливаем новую случайную цель, если включено случайное движение
                if (useRandomMovement)
                {
                    SetRandomTarget();
                }
            }
        }
    }

    // Устанавливаем новую случайную цель
    void SetRandomTarget()
    {
        float randomX = Random.Range(areaMin.x, areaMax.x);
        float randomY = Random.Range(areaMin.y, areaMax.y);
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }
}
