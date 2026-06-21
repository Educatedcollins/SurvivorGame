using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float damageCooldown = 1f;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI healthText;
    private int currentHealth;
    private float lastDamageTime;
    private bool isDead = false;
    private float deathTime;
    

    void Start()
    {
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown;
        UpdateHealthText();
    }

    void Update()
    {
        if (isDead && Time.time >= deathTime + 1f)
        {
            if (Input.anyKeyDown)
            {
                ReturnToMenu();
            }
        }
    }

void OnCollisionStay2D(Collision2D collision)
{
    if (isDead) return;

    if (collision.gameObject.CompareTag("Enemy"))
    {
        if (Time.time >= lastDamageTime + damageCooldown)
        {
            currentHealth--;
            lastDamageTime = Time.time;
            UpdateHealthText();

            if (currentHealth <= 0)
            {
                gameOverText.gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<PlayerMovement>().canMove = false;
                FindFirstObjectByType<EnemySpawner>().enabled = false;
                ScoreManager.instance.gameOver = true;
                isDead = true;
                deathTime = Time.time;
            }
        }
    }
}

    void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth;
    }
}