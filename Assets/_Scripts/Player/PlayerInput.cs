using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public Vector2 Movement;

    public InputAction Jumping => _input.Player.Jumping;

    public bool IsRunning => _input.Player.Running.IsPressed();

    private CustomInput _input;


    private void Awake()
    {
        _input = new();
        
    }


    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Movement.performed += OnMovementPerformed;
        _input.Player.Movement.canceled += OnMovementCanceled;

    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Movement.performed -= OnMovementPerformed;
        _input.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext obj)
    {
        Movement = obj.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext obj)
    {
        Movement = Vector2.zero;
    }
}
