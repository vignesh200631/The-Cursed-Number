
using UnityEngine;

public class MovingSpikeTrap : MonoBehaviour
{
    [Header("Movement Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;

    private Transform target;

    private void Start()
    {
        target = pointB;
        
    }

    private void Update()
    {
    
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerDeath player = other.GetComponentInParent<PlayerDeath>();

        if (player != null)
        {
            player.Die();
        }
    }
}
