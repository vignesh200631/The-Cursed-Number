
using UnityEngine;
using TMPro;
using System.Collections;

public class OpeningStoryController : MonoBehaviour
{
    public GameObject openingStoryPanel;
    public TMP_Text storyText;

    public MonoBehaviour playerController;
    public MonoBehaviour playerInteraction;

    [TextArea(5, 12)]
    public string openingStory =
        "Deep within an ancient land, a forgotten secret lies buried.\n\n" +
        "An archaeologist has arrived at a remote village after " +
        "discovering an ancient inscription mentioning the mysterious " +
        "number seven.\n\n" +
        "But something is wrong. The villagers fear the number seven, " +
        "and their king has forbidden anyone from speaking of it.\n\n" +
        "Determined to uncover the truth, the archaeologist begins " +
        "investigating the village.";

    private void Start()
    {
        openingStoryPanel.SetActive(true);

        storyText.text = openingStory;

        if (playerController != null)
            playerController.enabled = false;

        if (playerInteraction != null)
            playerInteraction.enabled = false;

        StartCoroutine(WaitForContinue());
    }

    private IEnumerator WaitForContinue()
    {
        yield return null;

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        openingStoryPanel.SetActive(false);

        if (playerController != null)
            playerController.enabled = true;

        if (playerInteraction != null)
            playerInteraction.enabled = true;
    }
}
