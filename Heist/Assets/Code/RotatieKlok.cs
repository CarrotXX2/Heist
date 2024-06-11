using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class RotatieKlok : MonoBehaviour
{
    private float duration = 3.0f; // De tijdsduur van de rotatie in seconden
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float elapsedTime = 0f;

    void Start()
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(-90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
        }
    }
}