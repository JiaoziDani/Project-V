using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    private PlayerInput.FootActions Foot;

    private PlayerMotor motor;
    private PlayerLook look;
    
    void Awake() {
        playerInput = new PlayerInput();
        Foot = playerInput.Foot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
            
        Foot.Jump.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(Foot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(Foot.Look.ReadValue<Vector2>());
    }

    private void OnEnable() {
        Foot.Enable();
    }

    private void OnDisable() {
        Foot.Disable();
    }
}
