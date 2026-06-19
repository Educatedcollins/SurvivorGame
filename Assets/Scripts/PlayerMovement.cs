using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        transform.Translate(movement * speed * Time.deltaTime);

        Wrap();
    }

void Wrap()
{
    Vector2 pos = transform.position;

    if (pos.x > 8.9f) pos.x = -8.9f;
    if (pos.x < -8.9f) pos.x = 8.9f;
    if (pos.y > 5f) pos.y = -5f;
    if (pos.y < -5f) pos.y = 5f;

    transform.position = pos;
}
}