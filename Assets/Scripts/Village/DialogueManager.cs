
using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    public float dialogueDuration = 5f;

    private Coroutine hideCoroutine;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue(string message)
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        dialoguePanel.SetActive(true);
        dialogueText.text = message;

        hideCoroutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(dialogueDuration);

        dialoguePanel.SetActive(false);
        hideCoroutine = null;
    }

    public void HideDialogue()
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
            hideCoroutine = null;
        }

        dialoguePanel.SetActive(false);
    }
}
