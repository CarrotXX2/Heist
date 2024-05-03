using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    public float destroyThreshold = 5f;
    private ParticleSystem particleSpawn;


    public void OnCollisionEnter(Collision collision)
    {
        // Check if the collision velocity magnitude is greater than the threshold
        if (collision.relativeVelocity.magnitude >= destroyThreshold)
        {

            Destroy(gameObject);
            
        }
    }
}