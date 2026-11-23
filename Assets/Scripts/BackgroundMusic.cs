using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            float volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            audioSource.volume = volume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource == null)
            return;

        audioSource.volume = volume;
    }

    public float GetVolume()
    {
        if (audioSource == null)
            return 1f;

        return audioSource.volume;
    }
}