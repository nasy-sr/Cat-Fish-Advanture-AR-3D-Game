using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager Instance;

    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip flipSound;
    public AudioClip matchSound;
    public AudioClip winSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //==========================
    // PLAY SFX
    //==========================

    public void PlayFlip()
    {
        sfxSource.PlayOneShot(flipSound);
    }

    public void PlayMatch()
    {
        sfxSource.PlayOneShot(matchSound);
    }

    public void PlayWin()
    {
        sfxSource.PlayOneShot(winSound);
    }

    //==========================
    // VOLUME
    //==========================

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }
}