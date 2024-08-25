using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{


    public float isGroundedSphereRadius;
    public LayerMask layerMask;

    private CharacterController _characterController;
    private Animator _animator;

    [SerializeField]
    private float _movementSpeed, _rotationSpeed, _jumpSpeed, _gravity;
    private Vector3 movementDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        var right = Camera.main.transform.right;
        right.y = 0;
        right = right.normalized;

        Vector3 inputMovement = forward * _movementSpeed * Input.GetAxisRaw("Vertical");
        inputMovement += right * _movementSpeed * Input.GetAxisRaw("Horizontal");
        _characterController.Move(inputMovement * Time.deltaTime);

        if (inputMovement.magnitude != 0)
        {
            transform.forward = Vector3.Lerp(transform.forward, inputMovement.normalized, 10*Time.deltaTime);
        }


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            movementDirection.y = _jumpSpeed;
            _animator.SetTrigger("jump");
        }
        movementDirection.y -= _gravity * Time.deltaTime;

        _characterController.Move(movementDirection * Time.deltaTime);

        _animator.SetBool("isRunning", inputMovement.magnitude != 0);

        _animator.SetBool("isInAir", !isGrounded());


    }

    bool isGrounded()
    {
        return Physics.CheckSphere(transform.position, isGroundedSphereRadius, layerMask);
    }
}
