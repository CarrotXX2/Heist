using UnityEngine;
using System.Collections;

public class LightIntensityController : MonoBehaviour
{
    public Light targetLight;       // De lichtbron die je wilt aanpassen
    public float pulseDuration = 0.5f; // De tijd in seconden voor de pulse (op en neer)
    public float interval = 60f;    // De tijdsinterval tussen pulses in seconden
    public AudioClip audioClip;     // De audioclip die je wilt afspelen
    private AudioSource audioSource; // De AudioSource component

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        StartCoroutine(PulseLightIntensity());
    }

    private IEnumerator PulseLightIntensity()
    {
        while (true)
        {
            float elapsedTime = 0f;
            float startIntensity = 0f;
            float peakIntensity = 900f;

            audioSource.Play();

            // Snel verhogen naar peakIntensity
            while (elapsedTime < pulseDuration / 2)
            {
                targetLight.intensity = Mathf.Lerp(startIntensity, peakIntensity, (elapsedTime / (pulseDuration / 2)));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0f;

            // Snel verlagen naar startIntensity
            while (elapsedTime < pulseDuration / 2)
            {
                targetLight.intensity = Mathf.Lerp(peakIntensity, startIntensity, (elapsedTime / (pulseDuration / 2)));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            targetLight.intensity = startIntensity;

            // Wacht het interval af voordat de volgende puls start
            yield return new WaitForSeconds(interval);
        }
    }
}