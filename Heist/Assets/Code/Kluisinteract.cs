using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Kluisinteract : MonoBehaviour
{
    public RaycastHit hit;
    public float rayLenght;
    public Canvas canvas;
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
                if (hit.collider.gameObject.CompareTag("Kluis"))
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    canvas.enabled = true;
                    
                }
            }
        }
    }
}
