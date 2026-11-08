
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public int correctAnswer = 6;

    [Header("Door Reference")]
    public AncientDoor ancientDoor;

    private bool isSolved;

    public void SubmitAnswer(int selectedAnswer)
    {
        if (isSolved)
            return;

        if (selectedAnswer == correctAnswer)
        {
            SolvePuzzle();
        }
        else
        {
            Debug.Log("Incorrect number! Try again.");
        }
    }

    private void SolvePuzzle()
    {
        isSolved = true;

        Debug.Log("Correct answer! Ancient door unlocked.");

        if (ancientDoor != null)
        {
            ancientDoor.OpenDoor();
        }
    }
}
