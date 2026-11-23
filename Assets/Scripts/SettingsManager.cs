using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject settingsPanel;

    [Header("Slider")]
    public Slider musicSlider;
    public Slider sfxSlider;

    private const string MUSIC_KEY = "MusicVolume";
    private const string SFX_KEY = "SFXVolume";

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        // Terapkan volume awal
        if (BackgroundMusic.Instance != null)
            BackgroundMusic.Instance.SetVolume(musicVolume);

        if (GameAudioManager.Instance != null)
            GameAudioManager.Instance.SetSFXVolume(sfxVolume);

        // Listener Slider
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    //==========================
    // OPEN / CLOSE
    //==========================

    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    //==========================
    // MUSIC
    //==========================

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MUSIC_KEY, volume);

        if (BackgroundMusic.Instance != null)
            BackgroundMusic.Instance.SetVolume(volume);

        PlayerPrefs.Save();
    }

    //==========================
    // SFX
    //==========================

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat(SFX_KEY, volume);

        if (GameAudioManager.Instance != null)
            GameAudioManager.Instance.SetSFXVolume(volume);

        PlayerPrefs.Save();
    }

    //==========================
    // RESET
    //==========================

    public void ResetSetting()
    {
        musicSlider.value = 1f;
        sfxSlider.value = 1f;

        SetMusicVolume(1f);
        SetSFXVolume(1f);
    }
}