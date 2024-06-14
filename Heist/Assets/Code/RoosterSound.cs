using UnityEngine;
using System.Collections;

public class PlaySoundAfterDelay : MonoBehaviour
{
    public AudioClip soundEffect; // Sleep je sound effect hierheen in de Inspector
    private AudioSource audioSource;

    public float delay = 5.0f; // De vertraging voordat het geluid afspeelt

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        Invoke("PlaySound", delay);
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(soundEffect);
    }
}