using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float rotationSpeed = 0;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private int maxJumps = 0;
    [SerializeField] private float gravity = 0;
    [SerializeField] private float dashSpeed = 0;
    [SerializeField] private float startDashTime = 0;
    [SerializeField] private float cooldownDashTime = 0;
    [SerializeField] private CharacterController controller;

    private static readonly int Jumping = Animator.StringToHash("Jumping");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private static readonly int Dashing = Animator.StringToHash("Dashing");
    private static readonly int TurningLeft = Animator.StringToHash("TurningLeft");
    private static readonly int TurningRight = Animator.StringToHash("TurningRight");
    Animator animator;
    private int numOfJumps;
    private float dashTime;
    private float verticalVelocity;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection = Vector3.forward;
    private float nextDashTime = 0f;
    private bool IsDashing = false;
    private bool Moving = false;
    Camera Camera;

    void Start()
    {
        Camera = Camera.main;
        animator = gameObject.GetComponent<Animator>();
        moveSpeed = PlayerStats.instance.move_speed;
        rotationSpeed = PlayerStats.instance.rotation_speed;
        jumpForce = PlayerStats.instance.jump_force;
        maxJumps = PlayerStats.instance.jump_number;
        gravity = PlayerStats.instance.gravity;
        dashSpeed = PlayerStats.instance.dash_speed;
        startDashTime = PlayerStats.instance.start_dash_time;
        cooldownDashTime = PlayerStats.instance.dash_cd * Upgrades.instance.dash_cdr;
        dashTime = 0;
    }
    private void Update()
    {
        Dash();
        if (!IsDashing)
        {
            MovementProccess();
            Jump();
        }
        RotationProcess();
        AnimatorHelper();
    }
    private void AnimatorHelper()
    {  
        animator.SetBool(Grounded, PlayerGrounded());
        
        if(PlayerGrounded() && Moving) animator.SetBool(IsMoving , true);
        else animator.SetBool(IsMoving, false);
    }
    private bool PlayerGrounded()
    {
        bool grounded = Physics.Raycast(controller.bounds.center, Vector3.down, controller.bounds.extents.y + 0.2f);

        if (grounded || controller.isGrounded)
        {
            return true;
        }
        return false;
        
    }
    private void Jump()
    {
        if (PlayerGrounded())
        {
            numOfJumps = 0;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && numOfJumps < maxJumps)
        {
            animator.SetTrigger(Jumping);
            verticalVelocity = jumpForce;
            numOfJumps++;
        }
    }


    private void MovementProccess()
    {
        //Animator
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            Moving = true;
        else
            Moving = false;

        var forward = Camera.transform.forward;
        var right = Camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        moveDirection = forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");
        
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
           
            lastMoveDirection = moveDirection;
        }
        moveDirection.y = verticalVelocity;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
    private void Dash()
    {
        Vector3 dashDirection;
        if(Time.time > nextDashTime)
        {
            if (Input.GetButtonDown("Dash"))
            {
                IsDashing = true;
                animator.SetTrigger(Dashing);
                dashTime = startDashTime;
                nextDashTime = Time.time + cooldownDashTime;
            }
        }
        if (dashTime > 0)
        {
            verticalVelocity = 0;
            dashTime -= Time.deltaTime;
            dashDirection = lastMoveDirection;
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
        }
        else IsDashing = false;
    }
    private void RotationProcess()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}