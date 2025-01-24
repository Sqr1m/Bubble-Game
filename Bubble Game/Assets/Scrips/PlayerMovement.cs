using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    void Update()
    {
        Vector3 newPosition = transform.position;

        newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }
}
