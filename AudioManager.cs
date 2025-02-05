using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip Ambiance;
    public AudioClip Underwater;

    private void Start()
    {
       // musicSource = GetComponent<AudioSource>();
        musicSource.clip = Ambiance;
        musicSource.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger
        if (other.CompareTag("Player"))
        {
            // Play the audio if it's not already playing
            if (!musicSource.isPlaying)
            {
                musicSource.clip = Underwater;
                musicSource.Play();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Stop the audio when the player exits the trigger
        if (other.CompareTag("Player"))
        {
            musicSource.clip = Underwater; 
            musicSource.Stop();
        }
    }
}
