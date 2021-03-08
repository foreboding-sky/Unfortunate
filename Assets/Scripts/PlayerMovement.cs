using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private float gravity = 50f;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float startDashTime = 0.1f;

    [SerializeField] private CharacterController controller;
    private int numOfJumps;
    private float dashTime;
    private float verticalVelocity;
    private Vector3 moveDirection;

    void Start()
    {
        dashTime = 0;
    }

    void Update()
    {
        Jump();
        MoveAndDash();
        RotationProcess();
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            numOfJumps = 0;
            verticalVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && numOfJumps < maxJumps)
        {
            verticalVelocity = jumpForce;
            numOfJumps++;
        }
    }

    public void MoveAndDash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            dashTime = startDashTime;
        }
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * dashSpeed, verticalVelocity, Input.GetAxis("Vertical") * moveSpeed * dashSpeed);
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, verticalVelocity, Input.GetAxis("Vertical") * moveSpeed);
        }
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void RotationProcess()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}