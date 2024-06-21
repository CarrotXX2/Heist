using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    public string objectName;
    public Transform hand;
    public float rayLength;
    public RaycastHit hit;
    public bool dropped;
    public float throwForce;
    public BoxCollider col;
    private bool hasBeenPickedUp = false;
    public float rayDistance = 5f;  // The distance the ray will travel
    public LayerMask doorLayer;     // The layer on which the door resides
    public AudioClip pickUp;

    private void Start()
    {

    }
    void Update()
    {
        if (!hasBeenPickedUp && Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
            {
                if (hit.transform.gameObject.CompareTag("Pickable"))
                {
                    objectName = hit.transform.gameObject.name;
                    GameObject objectToPickup = GameObject.Find(objectName);
                    col = objectToPickup.GetComponent<BoxCollider>();
                    col.enabled = false;
                    objectToPickup.transform.position = hand.position;
                    objectToPickup.transform.rotation = hand.rotation;
                    objectToPickup.transform.SetParent(hand); // Set the parent to the hand
                    Rigidbody OBJrigid = objectToPickup.GetComponent<Rigidbody>();
                    OBJrigid.isKinematic = true;
                    hasBeenPickedUp = true; // Set the flag to true to indicate it has been picked up
                    dropped = false;
                    AudioSource.PlayClipAtPoint(pickUp, hand.transform.position);
                }
            }
        }
        if (Input.GetKey(KeyCode.G))
        {
            if (dropped == false)
            {
                dropped = true;
                GameObject objectToDrop = GameObject.Find(objectName);
                Rigidbody rigidobj = objectToDrop.GetComponent<Rigidbody>();
                rigidobj.isKinematic = false;
                col.enabled = true;
                objectToDrop.transform.SetParent(null);
                hasBeenPickedUp = false;
            }
        }
        if (Input.GetKey(KeyCode.T))
        {
            if (dropped == false)
            {
                dropped = true;
                GameObject objectToDrop = GameObject.Find(objectName);
                Rigidbody rigidobj = objectToDrop.GetComponent<Rigidbody>();
                col.enabled = true;
                rigidobj.isKinematic = false;
                objectToDrop.transform.SetParent(null);
                rigidobj.velocity = Vector3.zero; // Reset the velocity
                rigidobj.AddForce(transform.forward * throwForce, ForceMode.Impulse); // Apply throw force
                hasBeenPickedUp = false;
            }
        }
        {
            if (Input.GetMouseButtonDown(0))  // Check for left mouse button click
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, rayDistance, doorLayer))
                {
                    DoorOpener doorController = hit.collider.GetComponent<DoorOpener>();
                    if (doorController != null)
                    {
                        doorController.ToggleDoor();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
            {
                if (hit.transform.gameObject.CompareTag("Bus"))
                {
                    SceneManager.LoadScene("BuyMenu 1");
                }
                else
                {
                    if (hit.transform.gameObject.CompareTag("Bus1"))
                    {
                        SceneManager.LoadScene("Silver");
                    }
                }
            }
        }
    }
}