using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    private bool isPaused = false;

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        masterSlider.onValueChanged.AddListener(OnMasterChanged);
        musicSlider.onValueChanged.AddListener(OnMusicChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    void OnMasterChanged(float value)
    {
        PlayerPrefs.SetFloat("MasterVolume", value);
        AudioListener.volume = value;
    }

    void OnMusicChanged(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        AudioManager.instance.SetMusicVolume(value);
    }

    void OnSFXChanged(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
        AudioManager.instance.SetSFXVolume(value);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenOptions()
    {
        PlayerPrefs.SetString("PreviousScene", "GameScene");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Options");
    }
}