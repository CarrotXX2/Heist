using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kluis : MonoBehaviour
{
    public int code;
    public Canvas canvas;
    public TMP_InputField charholder;
    public GameObject button0;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject clearButton;
    public GameObject enterButton;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void B1()
    {
        charholder.text = charholder.text + 1;
    }
    public void B2()
    {
        charholder.text = charholder.text + 2;
    }
    public void B3()
    {
        charholder.text = charholder.text + 3;
    }
    public void B4()
    {
        charholder.text = charholder.text + 4;
    }
    public void B5()
    {
        charholder.text = charholder.text + 5;
    }
    public void B6()
    {
        charholder.text = charholder.text + 6;
    }
    public void B7()
    {
        charholder.text = charholder.text + 7;
    }
    public void B8()
    {
        charholder.text = charholder.text + 8;
    }
    public void B9()
    {
        charholder.text = charholder.text + 9;
    }
    public void B0()
    {
        charholder.text = charholder.text + 0;
    }
    public void Clearbutton()
    {
        charholder.text = null;   
    }
    public void Enterbutton()
    {
        if (charholder.text == "9120")
        {
            Debug.Log("succes");
            canvas.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Debug.Log("false");
        }
    }
}
