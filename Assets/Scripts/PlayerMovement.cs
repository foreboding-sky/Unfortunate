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
    [SerializeField] private float dashSpeed = 100f;
    [SerializeField] private float startDashTime = 0.1f;
    [SerializeField] private float cooldownDashTime = 3f;
    [SerializeField] private CharacterController controller;

    private int numOfJumps;
    private float dashTime;
    private float verticalVelocity;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection = Vector3.forward;
    private float nextDashTime = 0f;
    void Start()
    {
        dashTime = 0;
    }
    void Update()
    {
        Move();
        Jump();
        Dash();
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
    public void Move()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), verticalVelocity, Input.GetAxis("Vertical"));
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lastMoveDirection = moveDirection;
        }
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void Dash()
    {
        Vector3 dashDirection;
        if(Time.time > nextDashTime)
        {
            if (Input.GetButtonDown("Dash"))
            {
                dashTime = startDashTime;
                nextDashTime = Time.time + cooldownDashTime;
            }
        }
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            dashDirection = lastMoveDirection;
            dashDirection.y = 0;
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
        }
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