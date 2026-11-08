
using UnityEngine;

public class AnswerButton : MonoBehaviour, IInteractable
{
    [Header("Answer Settings")]
    public int answerNumber;

    [Header("Puzzle Reference")]
    public PuzzleManager puzzleManager;

    public void Interact()
    {
        if (puzzleManager != null)
        {
            puzzleManager.SubmitAnswer(answerNumber);
        }
    }

    public string GetPrompt()
    {
        return "Press E to select " + answerNumber;
    }
}
