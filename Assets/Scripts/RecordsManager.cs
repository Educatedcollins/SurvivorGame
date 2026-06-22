using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RecordsManager : MonoBehaviour
{
    public TextMeshProUGUI scoresText;

    void Start()
    {
        DisplayScores();
    }

    void DisplayScores()
    {
        List<int> scores = ScoreManager.GetTopScores();

        if (scores.Count == 0)
        {
            scoresText.text = "No scores yet!\nPlay a game first.";
            return;
        }

        string display = "";
        for (int i = 0; i < scores.Count; i++)
        {
            display += (i + 1) + ".  " + scores[i] + " seconds\n";
        }

        scoresText.text = display;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}