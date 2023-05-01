using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip droneSound;

    private AudioSource musicSource;
    private AudioSource droneSource;

    void Start()
    {
        // Set up music source
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();

        // Set up drone sound source
        droneSource = gameObject.AddComponent<AudioSource>();
        droneSource.clip = droneSound;
        droneSource.loop = true;
        droneSource.Play();
    }
}
