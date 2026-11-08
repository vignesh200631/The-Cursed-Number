
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveEntrance : MonoBehaviour, IInteractable
{
    public string caveSceneName = "Cave";

    public void Interact()
    {
        Debug.Log("Entering the ancient cave...");
        SceneManager.LoadScene(caveSceneName);
    }

    public string GetPrompt()
    {
        return "Press E to enter the cave";
    }
}
