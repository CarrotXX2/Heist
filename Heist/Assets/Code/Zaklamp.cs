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
        loadflash();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && HasBought == 1)
        {
            flashlight.enabled = !flashlight.enabled;
        }
        SaveFlash();
    }

    public void SaveFlash()
    {
        PlayerPrefs.SetInt("HasBought", HasBought);
        PlayerPrefs.Save();
    }
    public void loadflash()
    {
        if (PlayerPrefs.HasKey("HasBought"))
        {
            HasBought = PlayerPrefs.GetInt("HasBought");
        }
    }
}
