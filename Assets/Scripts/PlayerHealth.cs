using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float damageCooldown = 1f;
    private int currentHealth;
    private float lastDamageTime;

    void Start()
    {
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                currentHealth--;
                lastDamageTime = Time.time;
                Debug.Log("Health: " + currentHealth);

                if (currentHealth <= 0)
                {
                    Debug.Log("Game Over!");
                    gameObject.SetActive(false);
                }
            }
        }
    }
}