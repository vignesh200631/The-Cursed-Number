
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -20f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private LayerMask groundMask;

    private CharacterController controller;
    private Animator anim;

    private Vector3 velocity;
    private Vector3 moveDirection;
    private float moveAmount;
    private bool isGrounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CheckGround();
        HandleMovement();
        HandleJump();
        ApplyGravity();
        MovePlayer();
        HandleAnimation();
    }

    private void CheckGround()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics.CheckSphere(
                groundCheck.position,
                groundDistance,
                groundMask
            );
        }
        else
        {
            isGrounded = controller.isGrounded;
        }

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
    }

    private void HandleMovement()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 inputVector = new Vector3(xInput, 0f, zInput);
        inputVector = Vector3.ClampMagnitude(inputVector, 1f);

        moveAmount = inputVector.magnitude;

        moveDirection = inputVector;

        if (Camera.main != null)
        {
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            moveDirection =
                forward * inputVector.z +
                right * inputVector.x;
        }

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
    }

    private void MovePlayer()
    {
        Vector3 horizontalMovement = moveDirection * moveSpeed;

        Vector3 finalMovement = horizontalMovement + velocity;

        controller.Move(finalMovement * Time.deltaTime);
    }

    private void HandleAnimation()
    {
        if (anim == null)
            return;

        float animationDamp = 0.15f;

        anim.SetFloat("Speed", moveAmount,animationDamp,Time.deltaTime);
        //anim.SetBool("IsGrounded", isGrounded);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        CollapsingPlatform platform =
            hit.collider.GetComponentInParent<CollapsingPlatform>();

        if (platform != null)
        {
            platform.TriggerPlatform();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundDistance
            );
        }
    }

    public void ResetVelocity()
    {
        velocity = Vector3.zero;
    }
}
