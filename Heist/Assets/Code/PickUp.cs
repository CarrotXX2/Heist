using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

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
    }
}