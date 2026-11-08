
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -20f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private float fixedZ;

    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock player to the side-scrolling plane
        fixedZ = transform.position.z;
    }

    void Update()
    {
        // Ground detection
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Left and right movement
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 move = new Vector3(horizontal, 0f, 0f);

        controller.Move(move * moveSpeed * Time.deltaTime);

        // Player rotation
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Lock Z position
        Vector3 position = transform.position;
        position.z = fixedZ;
        transform.position = position;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        CollapsingPlatform platform = hit.collider.GetComponent<CollapsingPlatform>();

        if(platform != null)
            platform.TriggerPlatform();    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position,groundDistance);
    }

    public void ResetVelocity()
    {
        velocity = Vector3.zero;
    }
}
