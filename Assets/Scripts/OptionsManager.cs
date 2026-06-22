using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        ApplyVolumes();

        masterSlider.onValueChanged.AddListener(OnMasterChanged);
        musicSlider.onValueChanged.AddListener(OnMusicChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
    }

    void OnMasterChanged(float value)
    {
        PlayerPrefs.SetFloat("MasterVolume", value);
        ApplyVolumes();
    }

    void OnMusicChanged(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        ApplyVolumes();
    }

    void OnSFXChanged(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
        ApplyVolumes();
    }

    void ApplyVolumes()
    {
        AudioListener.volume = masterSlider.value;
        AudioManager.instance.SetMusicVolume(musicSlider.value);
        AudioManager.instance.SetSFXVolume(sfxSlider.value);
    }

    public void GoBack()
    {
        string previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }
}