using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 direction = GetWrappedDirection();
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
        Wrap();
    }

    Vector2 GetWrappedDirection()
    {
        Vector2 diff = (Vector2)player.position - (Vector2)transform.position;

        if (Mathf.Abs(diff.x) > 8.9f) diff.x = -Mathf.Sign(diff.x) * (17.8f - Mathf.Abs(diff.x));
        if (Mathf.Abs(diff.y) > 5f) diff.y = -Mathf.Sign(diff.y) * (10f - Mathf.Abs(diff.y));

        return diff.normalized;
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