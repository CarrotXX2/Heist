using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobertticaSpawn : MonoBehaviour
{
    public GameObject robert;
    public GameObject robertica;
    public int equipNum;

    void Start()
    {
        // Load equipNum from PlayerPrefs on start
        equipNum = PlayerPrefs.GetInt("EquipNumber", 0); // Default value is 0 if not set

        // Update objects based on equipNum
        if (equipNum == 1)
        {
            robert.SetActive(false);
            robertica.SetActive(true);
        }
        else
        {
            robert.SetActive(true);
            robertica.SetActive(false);
        }
    }

    // Function to save equipNum to PlayerPrefs
    public void SaveEquipNum()
    {
        PlayerPrefs.SetInt("EquipNumber", equipNum);
        PlayerPrefs.Save(); // Save PlayerPrefs to disk
    }

    // Other methods in your class
    // ...
}