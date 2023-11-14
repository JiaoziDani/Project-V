using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    // Update is called once per frame
    private void Update()
    {
        MyInput();
    }
    

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MovePlayer()
    {
        
        //  Calculate movement direction by scaling axes by corresponding input
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //  Move the player's rigidbody via force in the calculated direction
        rb.AddForce(10f * moveSpeed * moveDirection.normalized, ForceMode.Force);
    }
}
