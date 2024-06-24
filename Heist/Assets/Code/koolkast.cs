using UnityEngine;
using TMPro;
using System.Collections;

public class Koolkast : MonoBehaviour
{
    public Transform objectToRotate;  // Het object dat moet draaien
    public float rotationSpeed = 1f;  // Snelheid van de rotatie
    public bool isLookingAtFridge;
    public Transform fridge;    


    void Update()
    {
        // Als de sleutel is opgepakt, draai het object als je naar de "Garage" kijkt
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15))
            {
                if (hit.collider.gameObject.CompareTag("Fridge"))
                {
                    RotateObject();
                }
            }
        }
    }

    bool IsLookingAtFridge()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == fridge.transform)
            {
                return true;
            }
        }
        return false;
    }




    void RotateObject()
    {
        Quaternion targetRotation = Quaternion.Euler(0, -166, 0); // Roteer naar 90 graden op de Z-as
        objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
