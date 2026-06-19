using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float damageCooldown = 1f;
    public TextMeshProUGUI gameOverText;
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
    gameOverText.gameObject.SetActive(true);
    gameObject.SetActive(false);
    FindObjectOfType<EnemySpawner>().enabled = false;
}
            }
        }
    }
}