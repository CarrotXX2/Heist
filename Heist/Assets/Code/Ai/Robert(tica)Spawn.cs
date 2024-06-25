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
        loadequipnum();

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
    public void loadequipnum()
    {
        if (PlayerPrefs.HasKey("EquipNumber"))
        {
            equipNum = PlayerPrefs.GetInt("EquipNumber");
        }
    }
    // Other methods in your class
    // ...
}