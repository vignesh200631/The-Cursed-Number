
using System.Collections;
using UnityEngine;

public class AncientDoor : MonoBehaviour
{
    [Header("Door Settings")]
    public float openDistance = 3f;
    public float openDuration = 1.5f;

    [Header("References")]
    public Collider doorCollider;

    private Vector3 closedPosition;
    private bool isOpen;

    private void Start()
    {
        closedPosition = transform.position;
    }

    public void OpenDoor()
    {
        if (isOpen)
            return;

        isOpen = true;

        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }

        StartCoroutine(OpenAnimation());
    }

    private IEnumerator OpenAnimation()
    {
        Vector3 openPosition =
            closedPosition + Vector3.up * openDistance;

        float timer = 0f;

        while (timer < openDuration)
        {
            timer += Time.deltaTime;

            float progress = Mathf.Clamp01(
                timer / openDuration
            );

            transform.position = Vector3.Lerp(
                closedPosition,
                openPosition,
                progress
            );

            yield return null;
        }

        transform.position = openPosition;

        Debug.Log("Ancient door opened!");
    }
}
