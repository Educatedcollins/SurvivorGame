using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    private float score;
    public bool gameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!gameOver)
        {
            score += Time.deltaTime;
            scoreText.text = "Score:  " + Mathf.FloorToInt(score);
        }
    }
}