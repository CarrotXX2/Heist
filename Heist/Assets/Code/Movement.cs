using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    public float vert;
    public float hor;
    public Vector3 movedir;
    public float walkspeed;
    public float sprintspeed;
    private Rigidbody rb;
    public float jumpforce = 6f;
    public bool isSprinting;

    public float swayAmount = 0.05f;
    public float swaySpeed = 5f;
    public float idleSwayAmount = 0.01f;
    public float idleSwaySpeed = 1f;
    private Vector3 initialCameraPosition;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        if (playerCamera != null)
        {
            initialCameraPosition = playerCamera.transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        movedir.z = vert;
        movedir.x = hor;

        isSprinting = Input.GetKey(KeyCode.LeftShift);
        transform.Translate(movedir * Time.deltaTime * (isSprinting ? sprintspeed : walkspeed));

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (playerCamera != null)
        {
            ApplyCameraSway();
        }
    }

    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    void ApplyCameraSway()
    {
        bool isMoving = vert != 0 || hor != 0;
        float currentSwayAmount = isMoving ? swayAmount : idleSwayAmount;
        float currentSwaySpeed = isMoving ? swaySpeed : idleSwaySpeed;

        float swayX = Mathf.Sin(Time.time * currentSwaySpeed) * currentSwayAmount;
        float swayY = Mathf.Cos(Time.time * currentSwaySpeed) * currentSwayAmount;
        playerCamera.transform.localPosition = initialCameraPosition + new Vector3(swayX, swayY, 0);
    }

    public void death()
    {
        walkspeed = 0;
        sprintspeed = 0;
    }
}
