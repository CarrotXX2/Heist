using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Zaklamp : MonoBehaviour
{
    public GameObject flashLight;
    bool flashOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (!flashOn)
            {
                flashLight.SetActive(true);
                flashOn = true;
            }
            else
            { 
              flashLight.SetActive(false);
                flashOn = false;
            }
        }
    }
}
