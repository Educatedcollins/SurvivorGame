using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenOptions()
{
    PlayerPrefs.SetString("PreviousScene", "MainMenu");
    SceneManager.LoadScene("Options");
}
public void OpenRecords()
{
    PlayerPrefs.SetString("PreviousScene", "MainMenu");
    SceneManager.LoadScene("Records");
}
public void QuitGame()
{
    Application.Quit();
}
}