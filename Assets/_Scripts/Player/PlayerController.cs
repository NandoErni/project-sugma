using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController)),
    RequireComponent(typeof(PlayerAnimationController)),
    RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [Header("Grounding Check")]
    public float isGroundedSphereRadius;
    public LayerMask layerMask;

    private CharacterController _characterController;
    private PlayerAnimationController _animator;
    private PlayerInput _input;


    [SerializeField]
    private float _movementSpeed, _rotationSpeed, _jumpSpeed, _gravity;
    private Vector3 _velocity;

    private void OnDisable()
    {

        _input.Jumping.performed -= OnJumping;
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<PlayerAnimationController>();
        _input = GetComponent<PlayerInput>();
        _input.Jumping.performed += OnJumping;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovePlayer();


        HandleGravity();

    }

    private Vector3 GetMovementDirection()
    {
        var cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;

        var cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;

        return cameraForward * _input.Movement.y + cameraRight * _input.Movement.x;
    }

    private void MovePlayer()
    {
        var movementDirection = GetMovementDirection();
        movementDirection = movementDirection.normalized * _movementSpeed * Time.deltaTime;

        _characterController.Move(movementDirection);

        if (movementDirection.magnitude != 0)
        {
            transform.forward = Vector3.Lerp(transform.forward, movementDirection.normalized, 5 * Time.deltaTime);
        }

        _animator.IsRunning = movementDirection.magnitude != 0;
    }

    private void HandleGravity()
    {
        if (isGrounded() && _velocity.y < 0)
        {
            _velocity.y = -2;
        }
        _velocity.y -= _gravity * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);

        _animator.IsInAir = !isGrounded();
    }

    private void OnJumping(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
        if (isGrounded())
        {
            Debug.Log("Puj");
            _velocity.y = _jumpSpeed;
            _animator.PlayJump();
        }
    }

    private bool isGrounded()
    {
        return _characterController.isGrounded;
        return Physics.CheckSphere(transform.position, isGroundedSphereRadius, layerMask);
    }
}
