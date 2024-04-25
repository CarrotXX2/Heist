using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vert;
    public float hor;
    public Vector3 movedir;
    public float speed;
    public float sprintSpeedMultiplier = 1.25f;
    private bool isSprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        vert = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        movedir.z = vert;
        movedir.x = hor;

        float currentSpeed = speed;

        if (isSprinting)
        {
            currentSpeed *= sprintSpeedMultiplier;
        }
        transform.Translate(movedir * Time.deltaTime * currentSpeed);
    }
}