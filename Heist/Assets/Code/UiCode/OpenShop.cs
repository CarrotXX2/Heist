using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class
    OpenShop : MonoBehaviour
{
    public float rayLength;
    public RaycastHit hit;
    public Camera playCam;
    public Camera buyCam;
    private Camera activeCamera;
    public Canvas shopscreen;
    public bool shopOpen;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        shopOpen = false;
        shopscreen.enabled = false;
        activeCamera = playCam;
        playCam.enabled = true;
        buyCam.enabled = false;
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
            {
                if (hit.transform.gameObject.CompareTag("Shop") && !shopOpen)
                {
                    SwitchCamera();
                    shopscreen.enabled = true;
                    shopOpen = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    player.SetActive(false);
                }
            }
        }
    }
    public void SwitchCamera()
    {
        // Switch active camera
        if (activeCamera == playCam)
        {
            playCam.enabled = false;
            buyCam.enabled = true;
            activeCamera = buyCam;
        }
        else
        {
            playCam.enabled = true;
            buyCam.enabled = false;
            activeCamera = playCam;
        }
    }
}
