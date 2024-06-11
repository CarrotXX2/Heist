using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class RotatieKlok1 : MonoBehaviour
{
    private float duration = 5.0f; // De tijdsduur van de rotatie in seconden
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float elapsedTime = 0f;

    void Start()
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(-270, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
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