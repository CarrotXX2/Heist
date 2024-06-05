using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas main;
    public Canvas settings;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setclicked()
    {
        main.enabled = false;
        settings.enabled = true;
    }
    public void playclicked()
    {
        SceneManager.LoadScene("Finn");
    }
    public void onquit()
    {
        Application.Quit();
    }
}
