using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] audioSources;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

        // Inicializa los AudioSources
        audioSources = GetComponents<AudioSource>();
    }

    // Reproduce un sonido por su nombre
    public void PlaySound(string soundName)
    {
        AudioSource audioSource = FindAvailableAudioSource();

        if (audioSource != null)
        {
            AudioClip clip = Resources.Load<AudioClip>(soundName);

            if (clip != null)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Audio clip not found: " + soundName);
            }
        }
        else
        {
            Debug.LogWarning("No available AudioSources!");
        }
    }

    public void StopSound(string soundName)
    {
        foreach (var audioSource in audioSources)
        {
            if (audioSource.isPlaying && audioSource.clip != null && audioSource.clip.name == soundName)
            {
                audioSource.Stop();
                return;
            }
        }

        Debug.LogWarning("Sound not found or not playing: " + soundName);
    }


    // Encuentra un AudioSource disponible para reproducir un sonido
    private AudioSource FindAvailableAudioSource()
    {
        foreach (var audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                return audioSource;
            }
        }
        return null;
    }
}
