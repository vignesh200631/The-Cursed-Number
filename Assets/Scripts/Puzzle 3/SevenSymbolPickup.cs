
using UnityEngine;

public class SevenSymbolPickup : MonoBehaviour, IInteractable
{
    public bool IsCollected { get; private set; }

    public void Interact()
    {
        if (IsCollected)
            return;

        IsCollected = true;

        Debug.Log("Ancient Seven Symbol collected!");

        gameObject.SetActive(false);
    }

    public string GetPrompt()
    {
        return "Press E to collect the Seven Symbol";
    }
}
