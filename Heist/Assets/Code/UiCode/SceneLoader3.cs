using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader3 : MonoBehaviour
{
    public void playclicked()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Silver");

    }
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}