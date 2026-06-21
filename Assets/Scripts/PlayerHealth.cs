using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float damageCooldown = 1f;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI continueText;
    public TextMeshProUGUI healthText;
    private int currentHealth;
    private float lastDamageTime;
    private bool isDead = false;
    private float deathTime;
    private SpriteRenderer sr;

    void Start()
    {
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown;
        sr = GetComponent<SpriteRenderer>();
        UpdateHealthText();
    }

    void Update()
    {
        if (isDead && Time.time >= deathTime + 1f)
        {
            if (!continueText.gameObject.activeSelf)
            {
                continueText.gameObject.SetActive(true);
            }

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
                StartCoroutine(FlashRed());

                if (currentHealth <= 0)
                {
                    gameOverText.gameObject.SetActive(true);
                    sr.enabled = false;
                    GetComponent<PlayerMovement>().canMove = false;
                    FindFirstObjectByType<EnemySpawner>().enabled = false;
                    ScoreManager.instance.gameOver = true;
                    isDead = true;
                    deathTime = Time.time;
                }
            }
        }
    }

    IEnumerator FlashRed()
    {
        Color originalColor = sr.color;
        sr.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        sr.color = originalColor;
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