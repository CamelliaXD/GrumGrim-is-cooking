using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueOJ testDialogue;

    private TextEffect textEffect;

    private void Start()
    {
        textEffect = GetComponent<TextEffect>();
        CloseDialogueBox();
        ShowDialogueOJ(testDialogue);
    }

    public void ShowDialogueOJ (DialogueOJ dialogueOJ)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepDialogue(dialogueOJ));
    }

    private IEnumerator StepDialogue(DialogueOJ dialogueOJ)
    {

        foreach (string dialogue in dialogueOJ.Dialogue)
        {
            yield return textEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
        CloseDialogueBox();
    }
    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
