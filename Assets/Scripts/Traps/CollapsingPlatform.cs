
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollapsingPlatform : MonoBehaviour
{
    [Header("Collapse Settings")]
    public float collapseDelay = 1.5f;
    public float destroyDelay = 5f;

    private Rigidbody rb;
    private bool isTriggered;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void TriggerPlatform()
    {
        isTriggered = true;

        StartCoroutine(Collapse());
    }

    private IEnumerator Collapse()
    {
        // Wait before collapsing
        yield return new WaitForSeconds(collapseDelay);

        // Enable physics
        rb.isKinematic = false;
        rb.useGravity = true;

        // Remove platform after falling
        Destroy(gameObject, destroyDelay);
    }
}
