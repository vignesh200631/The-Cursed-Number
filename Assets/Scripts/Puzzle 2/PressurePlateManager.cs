
using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public int totalPlates = 7;

    [Header("References")]
    public AncientDoor ancientDoor;
    public PressurePlate[] pressurePlates;

    private int currentStep = 1;
    private bool isSolved;

    public void ActivatePlate(PressurePlate plate)
    {
        if (isSolved)
            return;

        if (plate.plateNumber == currentStep)
        {
            Debug.Log("Correct plate: " + currentStep);

            plate.SetActivated();

            currentStep++;

            if (currentStep > totalPlates)
            {
                SolvePuzzle();
            }
        }
        else
        {
            Debug.Log("Wrong plate! Sequence reset.");

            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        currentStep = 1;

        foreach (PressurePlate plate in pressurePlates)
        {
            plate.ResetPlate();
        }
    }

    private void SolvePuzzle()
    {
        isSolved = true;

        Debug.Log("All seven plates activated! Puzzle solved.");

        if (ancientDoor != null)
        {
            ancientDoor.OpenDoor();
        }
    }
}
