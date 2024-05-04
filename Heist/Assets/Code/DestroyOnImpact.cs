using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DestroyOnImpact : MonoBehaviour
{
    public float destroyThreshold = 5f;
    public GameObject particlePrefab; // Assign the particle prefab in the inspector
    public GameObject glass;
    public AudioClip soundclip;

    public void OnCollisionEnter(Collision collision)
    {
        // Check if the collision velocity magnitude is greater than the threshold
        if (collision.relativeVelocity.magnitude >= destroyThreshold)
        {
            Instantiate(particlePrefab, transform.position, transform.rotation);
            StartCoroutine(DestroyGlassAfterDelay(3f));
            glass.SetActive(false);
            AudioSource.PlayClipAtPoint(soundclip, transform.position);
        }
    }

    IEnumerator DestroyGlassAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}