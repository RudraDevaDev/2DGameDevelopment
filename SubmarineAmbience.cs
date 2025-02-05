using UnityEngine;
using System.Collections;

public class SubmarineAmbience : MonoBehaviour
{
    public AudioClip surfaceAudioClip;      // Assign surface ambiance in Inspector
    public AudioClip underwaterAudioClip;   // Assign underwater ambiance in Inspector
    public float fadeDuration = 1f;         // Control fade effect

    private AudioSource audioSource;
    private bool isUnderwater = false;
    private Coroutine fadeCoroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;  // Ensure ambiance loops
        audioSource.volume = 1f;   // Set initial volume
        audioSource.clip = surfaceAudioClip;  // Set starting ambiance
        audioSource.Play();  // Start playing the initial ambiance
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SurfaceZone") && isUnderwater)
        {
            isUnderwater = false;
            SwitchAmbience(surfaceAudioClip);
        }
        else if (other.CompareTag("UnderwaterZone") && !isUnderwater)
        {
            isUnderwater = true;
            SwitchAmbience(underwaterAudioClip);
        }
    }

    void SwitchAmbience(AudioClip newClip)
    {
        if (audioSource.clip == newClip) return;  // Prevent unnecessary changes

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeAudio(newClip, fadeDuration));
    }

    IEnumerator FadeAudio(AudioClip newClip, float duration)
    {
        float startVolume = audioSource.volume;

        // Fade out
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.clip = newClip;
        audioSource.Play();

        // Fade in
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, startVolume, t / duration);
            yield return null;
        }

        audioSource.volume = startVolume;
    }
}
