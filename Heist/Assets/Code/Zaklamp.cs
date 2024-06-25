using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Zaklamp : MonoBehaviour
{
    public Light flashlight;
    public int HasBought;
    void Start()
    {
        flashlight.enabled = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && HasBought == 1)
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }

    public void SaveFlash()
    { 
     
    }
}
