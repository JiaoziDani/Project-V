using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float xSensitivity;
    public float ySensitivity;
    
    float xRotation;
    float yRotation;

    public Transform orientation;
    void Start()
    {
        //  Lock cursor to center of screen and set invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //  Get input from mouse - X/Y axes
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        //  Apply input values to obtain rotation delta
        yRotation += mouseX;
        xRotation -= mouseY;

        //  Set a +/- 90 deg clamp to prevent unlimited rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //  Apply rotation to camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //  Apply rotation to player model
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
