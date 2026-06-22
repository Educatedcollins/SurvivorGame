using System.Collections.Generic;
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

    public void SaveScore()
    {
        int finalScore = Mathf.FloorToInt(score);
        List<int> scores = GetTopScores();
        scores.Add(finalScore);
        scores.Sort((a, b) => b.CompareTo(a));

        if (scores.Count > 10)
            scores.RemoveRange(10, scores.Count - 10);

        for (int i = 0; i < scores.Count; i++)
            PlayerPrefs.SetInt("Score_" + i, scores[i]);

        PlayerPrefs.SetInt("ScoreCount", scores.Count);
        PlayerPrefs.Save();
    }

    public static List<int> GetTopScores()
    {
        List<int> scores = new List<int>();
        int count = PlayerPrefs.GetInt("ScoreCount", 0);
        for (int i = 0; i < count; i++)
            scores.Add(PlayerPrefs.GetInt("Score_" + i, 0));
        return scores;
    }
}