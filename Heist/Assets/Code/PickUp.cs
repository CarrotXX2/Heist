using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string objectName;
    public GameObject hand;
    public float rayLenght;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLenght))
            {
                if (hit.transform.gameObject.CompareTag("Pickable"))
                {
                    Instantiate(GameObject.Find(objectName), hand.transform.position, transform.rotation);
                }
            }
        }
    }
}
