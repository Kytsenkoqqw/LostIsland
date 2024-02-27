using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float rotationSpeed = 100f;
    private float _currentSpeed;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Quaternion rotation;

        // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartMove();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(horizontalInput, 0f, verticalInput);
        moveVelocity = moveInput.normalized * _moveSpeed;

        // Поворачиваем персонаж в направлении движения
        if (moveInput != Vector3.zero)
        {
            rotation = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void StartMove()
    {
        _currentSpeed = _moveSpeed;
    }
}
