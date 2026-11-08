
using UnityEngine;

public class SevenSymbolDoor : MonoBehaviour, IInteractable
{
    public SevenSymbolPickup symbolPickup;
    public AncientDoor ancientDoor;

    private bool isUnlocked;

    public void Interact()
    {
        if (isUnlocked)
            return;

        if (symbolPickup == null || ancientDoor == null)
        {
            Debug.LogWarning("Puzzle references are missing!");
            return;
        }

        if (symbolPickup.IsCollected)
        {
            isUnlocked = true;

            Debug.Log("Seven Symbol placed! Ancient door unlocked.");

            ancientDoor.OpenDoor();
        }
        else
        {
            Debug.Log("The door requires the missing Seven Symbol.");
        }
    }

    public string GetPrompt()
    {
        if (symbolPickup != null && symbolPickup.IsCollected)
            return "Press E to place the Seven Symbol";

        return "The door has an empty symbol slot";
    }
}
