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
        Vector2 newPosition = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.position = newPosition;
    }
}