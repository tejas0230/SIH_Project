using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    // [SerializeField] private DialogueObject testDialogue;

    public bool IsOpen {get; private set;}

    private ResponseHandler responseHandler;
    private TypeWriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect=GetComponent<TypeWriterEffect>();
        responseHandler=GetComponent<ResponseHandler>();
        CloseDialogueBox();
        // ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
 
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        // yield return new Wait ForSeconds(2);
        // foreach(string dialogue in dialogueObject.Dialogue)
        // {
        //     yield return typewriterEffect.Run(dialogue,textLabel);
        //     yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); 
        // }

        for (int i=0;i < dialogueObject.Dialogue.Length;i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue,textLabel);

            if(i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
             CloseDialogueBox();
        }

    }

    private void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
