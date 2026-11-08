
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [Header("Checkpoint Settings")]
    public Transform initialCheckpoint;

    private Transform currentCheckpoint;

    private void Awake()
    {
        currentCheckpoint = initialCheckpoint;

        if (currentCheckpoint == null)
        {
            Debug.LogError("Initial Checkpoint is not assigned!");
        }
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;

        Debug.Log("Checkpoint activated: " + checkpoint.name);
    }

    public Transform GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }
}
