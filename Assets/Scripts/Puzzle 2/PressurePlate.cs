
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Plate Settings")]
    public int plateNumber;

    [Header("Puzzle Reference")]
    public PressurePlateManager puzzleManager;

    private bool isActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated)
            return;

        PlayerController player =
            other.GetComponentInParent<PlayerController>();

        if (player != null)
        {
            puzzleManager.ActivatePlate(this);
        }
    }

    public void SetActivated()
    {
        isActivated = true;

        // Change plate color
        Renderer plateRenderer = GetComponent<Renderer>();

        if (plateRenderer != null)
        {
            plateRenderer.material.color = Color.green;
        }
    }

    public void ResetPlate()
    {
        isActivated = false;

        Renderer plateRenderer = GetComponent<Renderer>();

        if (plateRenderer != null)
        {
            plateRenderer.material.color = Color.white;
        }
    }
}
