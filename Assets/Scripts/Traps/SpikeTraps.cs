
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerDeath player = other.GetComponentInParent<PlayerDeath>();

        if (player != null)
        {
            player.Die();
        }
    }
}
