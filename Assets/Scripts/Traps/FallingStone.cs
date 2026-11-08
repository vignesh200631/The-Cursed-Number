
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingStone : MonoBehaviour
{
    public float fallSpeed = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.linearVelocity = Vector3.down * fallSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
        PlayerDeath player = collision.collider.GetComponentInParent<PlayerDeath>();

        if (player != null)
        {
            Destroy(gameObject);
            player.Die();
        }
    }
}
