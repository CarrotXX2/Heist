using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    public Transform body;
    public float mouseX;
    public Vector3 bodyRot;
    public float rotSpeed2;

    void start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        bodyRot.y = mouseX;
        body.Rotate(bodyRot * rotSpeed2 * Time.deltaTime);
    }
}