using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour
{
    public Canvas pause;
    public Canvas settings;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SettingsCLicked()
    {
        pause.enabled = false;
        settings.enabled = true;
        Time.timeScale = 1.0f;
    }
    public void resume()
    {
        pause.enabled = false;
        settings.enabled = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
