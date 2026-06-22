using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioClip damageSound;
    public AudioClip spawnSound;
    private AudioSource sfxSource;
    private AudioSource musicSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        sfxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
    }

    void Start()
    {
        ApplySavedVolumes();
        PlayMusicForScene(SceneManager.GetActiveScene().name);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        if (sceneName == "Options") return;

        AudioClip musicToPlay = null;

        if (sceneName == "MainMenu")
            musicToPlay = mainMenuMusic;
        else if (sceneName == "GameScene")
            musicToPlay = gameMusic;

        if (musicToPlay != null && musicSource.clip != musicToPlay)
        {
            musicSource.clip = musicToPlay;
            musicSource.Play();
        }
    }

    void ApplySavedVolumes()
    {
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 1f);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void PlayDamageSound()
    {
        if (damageSound != null)
            sfxSource.PlayOneShot(damageSound);
    }

    public void PlaySpawnSound()
    {
        if (spawnSound != null)
            sfxSource.PlayOneShot(spawnSound);
    }
}