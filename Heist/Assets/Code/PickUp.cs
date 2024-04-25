using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string objectName;
    public Transform hand;
    public float rayLength;
    public RaycastHit hit;
    public bool dropped;

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
                Instantiate(GameObject.Find(objectName), hand.transform.position, hand.transform.rotation);
                GameObject objectToDrop = GameObject.Find(objectName);
                Rigidbody rigidobj = objectToDrop.GetComponent<Rigidbody>();
                rigidobj.isKinematic = false;
                hasBeenPickedUp = false;
                
            }

        }
    }
}