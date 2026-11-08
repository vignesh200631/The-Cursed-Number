
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerDeath : MonoBehaviour
{
    [Header("References")]
    public CheckpointManager checkpointManager;

    [Header("Death Settings")]
    public float respawnDelay = 0.5f;

    private CharacterController controller;
    private PlayerController playerController;

    private bool isDead;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;

        Debug.Log("Player died!");

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        // Disable player movement
        if (playerController != null)
            playerController.enabled = false;

        controller.enabled = false;

        // Wait before respawning
        yield return new WaitForSeconds(respawnDelay);

        Transform checkpoint =
            checkpointManager.GetCurrentCheckpoint();

        if (checkpoint != null)
        {
            // Reset player position and rotation
            transform.SetPositionAndRotation(
                checkpoint.position,
                checkpoint.rotation
            );
        }
        else
        {
            Debug.LogError("No checkpoint available!");
        }

        // Reset movement velocity
        if (playerController != null)
            playerController.ResetVelocity();

        // Enable player
        controller.enabled = true;

        if (playerController != null)
            playerController.enabled = true;

        isDead = false;

        Debug.Log("Player respawned!");
    }
}
