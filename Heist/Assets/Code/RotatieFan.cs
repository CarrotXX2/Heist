using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatieFan : MonoBehaviour
{
    public float rotationSpeed = 100;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}