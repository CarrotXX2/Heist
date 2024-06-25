using UnityEngine;

public class Koolkast : MonoBehaviour
{
    public Transform objectToRotate;  // Het object dat moet draaien
    public float rotationSpeed = 1f;  // Snelheid van de rotatie
    public Transform fridge;

    private bool isOpening = false;

    void Update()
    {
        // Als de sleutel is opgepakt, draai het object als je naar de "Garage" kijkt
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15))
            {
                if (hit.collider.gameObject.CompareTag("Fridge"))
                {
                    isOpening = true;
                }
            }
        }

        if (isOpening)
        {
            RotateObject();
        }
    }

    void RotateObject()
    {
        Quaternion targetRotation = Quaternion.Euler(0, -166, 0); // Roteer naar 90 graden op de Z-as
        objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Stop rotating once the object is close enough to the target rotation
        if (Quaternion.Angle(objectToRotate.rotation, targetRotation) < 0.1f)
        {
            objectToRotate.rotation = targetRotation; // Snap to the target rotation
            isOpening = false; // Stop rotating
        }
    }
}