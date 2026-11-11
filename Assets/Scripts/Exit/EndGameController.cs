
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameController : MonoBehaviour
{
    [Header("Ending Panels")]
    public GameObject endStoryPanel;
    public GameObject endGamePanel;


    [Header("End Game Text")]
    public TMP_Text endGameText;

    [Header("Player Components")]
    public PlayerController playerController;
    public PlayerInteraction playerInteraction;

    [Header("Main Menu")]
    public string mainMenuSceneName = "MainMenu";

    private bool isEndingStarted;
    private int endingStage = 0;

    private void Start()
    {
        endStoryPanel.SetActive(false);
        endGamePanel.SetActive(false);
    }

    private void Update()
    {
        if (!isEndingStarted)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueEnding();
        }
    }

    public void StartEnding()
    {
        if (isEndingStarted)
            return;

        isEndingStarted = true;
        endingStage = 1;

        if (playerController != null)
            playerController.enabled = false;

        if (playerInteraction != null)
            playerInteraction.enabled = false;

        endStoryPanel.SetActive(true);

    }

    private void ContinueEnding()
    {
        if (endingStage == 1)
        {
            endStoryPanel.SetActive(false);
            endGamePanel.SetActive(true);

            endGameText.text = "THE END";

            endingStage = 2;
        }
        else if (endingStage == 2)
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
