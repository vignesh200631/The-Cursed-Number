
using UnityEngine;

public class VillagerDialogue : MonoBehaviour, IInteractable
{
    [TextArea(2, 5)]
    public string dialogue;

    public DialogueManager dialogueManager;

    public void Interact()
    {
        if (dialogueManager != null)
        {
            dialogueManager.ShowDialogue(dialogue);
        }
    }

    public string GetPrompt()
    {
        return "Press E to talk";
    }
}
