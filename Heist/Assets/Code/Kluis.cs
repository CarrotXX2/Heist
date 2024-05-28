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
    public AudioClip CLick;
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
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void B2()
    {
        charholder.text = charholder.text + 2;
        AudioSource.PlayClipAtPoint(CLick, transform.position);

    }
    public void B3()
    {
        charholder.text = charholder.text + 3;
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void B4()
    {
        charholder.text = charholder.text + 4;
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void B5()
    {
        charholder.text = charholder.text + 5;
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void B6()
    {
        charholder.text = charholder.text + 6;
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void B7()
    {
        charholder.text = charholder.text + 7;
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void B8()
    {
        charholder.text = charholder.text + 8;
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void B9()
    {
        charholder.text = charholder.text + 9;
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void B0()
    {
        charholder.text = charholder.text + 0;
        AudioSource.PlayClipAtPoint(CLick, transform.position);
    }
    public void Clearbutton()
    {
        AudioSource.PlayClipAtPoint(CLick, transform.position);
        charholder.text = null;   
    }
    public void Enterbutton()
    {
        AudioSource.PlayClipAtPoint(CLick, transform.position);
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
