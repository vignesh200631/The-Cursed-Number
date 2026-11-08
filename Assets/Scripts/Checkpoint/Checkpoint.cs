
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerDeath player = other.GetComponentInParent<PlayerDeath>();

        if (player != null)
        {
            if (player.checkpointManager != null)
            {
                player.checkpointManager.SetCheckpoint(transform);

                Debug.Log("New checkpoint reached!");
            }
        }
    }
}
