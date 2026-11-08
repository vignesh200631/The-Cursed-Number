
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactionRange = 2f;

    private IInteractable currentInteractable;

    void Update()
    {
        FindInteractable();

        if (currentInteractable != null &&
            Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    void FindInteractable()
    {
        currentInteractable = null;

        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            interactionRange
        );

        float closestDistance = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            IInteractable interactable =
                hit.GetComponentInParent<IInteractable>();

            if (interactable == null)
                continue;

            float distance = Vector3.Distance(
                transform.position,
                hit.ClosestPoint(transform.position)
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentInteractable = interactable;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            transform.position,
            interactionRange
        );
    }
}
