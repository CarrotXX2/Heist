using UnityEngine;
using TMPro;
using System.Collections;

public class KeyPickup : MonoBehaviour
{
    public Transform objectToRotate;  // Het object dat moet draaien
    public GameObject key;            // De sleutel in de scene
    public float rotationSpeed = 1f;  // Snelheid van de rotatie
    public TextMeshProUGUI pickupText; // TextMeshPro tekst object dat verschijnt bij het oppakken van de sleutel
    public Transform teleportTarget;  // Het doel waar de sleutel naar geteleporteerd wordt

    private bool hasKey = false;      // Om bij te houden of de sleutel is opgepakt
    private AudioSource audioSource;  // AudioSource component

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (pickupText != null)
        {
            pickupText.gameObject.SetActive(false); // Verberg de tekst bij het starten
        }
    }

    void Update()
    {
        // Checken of de 'E' toets wordt ingedrukt en of we naar de sleutel kijken
        if (Input.GetKeyDown(KeyCode.E) && IsLookingAtKey())
        {
            PickUpKey();
        }

        // Als de sleutel is opgepakt, draai het object als je naar de "Garage" kijkt
        if (hasKey && Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15))
            {
                if (hit.collider.gameObject.CompareTag("Garage"))
                {
                    RotateObject();
                }
            }
        }
    }

    bool IsLookingAtKey()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == key.transform)
            {
                return true;
            }
        }
        return false;
    }

    void PickUpKey()
    {
        hasKey = true;
        ShowPickupText();
        TeleportKey(); // Teleporteer de sleutel in plaats van deze te vernietigen
    }


    void ShowPickupText()
    {
        if (pickupText != null)
        {
            pickupText.gameObject.SetActive(true);
            StartCoroutine(HidePickupText());
        }
    }

    IEnumerator HidePickupText()
    {
        yield return new WaitForSeconds(2); // Wacht 2 seconden
        pickupText.gameObject.SetActive(false);
    }

    void TeleportKey()
    {
        if (teleportTarget != null)
        {
            key.transform.position = teleportTarget.position;
        }
    }

    void RotateObject()
    {
        Quaternion targetRotation = Quaternion.Euler(-90, -90, 0); // Roteer naar 90 graden op de Z-as
        objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
