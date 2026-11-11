
using UnityEngine;

public class FinalExit : MonoBehaviour
{
    public SevenSymbolPickup symbolPickup;
    public EndGameController endGameController;

    private bool isCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (isCompleted)
            return;

        PlayerController player =
            other.GetComponentInParent<PlayerController>();

        if (player == null)
            return;

        if (symbolPickup != null && symbolPickup.IsCollected)
        {
            isCompleted = true;

            Debug.Log("Final exit reached!");

            endGameController.StartEnding();
        }
        else
        {
            Debug.Log("Collect the Seven Symbol first!");
        }
    }
}
