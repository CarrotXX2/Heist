using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Zaklamp : MonoBehaviour
{
    public Light flashlight;

    void Start()
    {
        // Make sure flashlight is off when the game starts
        flashlight.enabled = false;
    }

    void Update()
    {
        // Toggle flashlight on/off when the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
