using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using



public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;
    public bool CamMove;
    public Image speakerObj;
    private SpriteRenderer speakerRender;
    public Sprite rjhImage;
    public Sprite paImage;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        //when this has a null reference the players movement is reversed for some reason 
        //speakerRender = speakerObj.GetComponent<SpriteRenderer>();

        CloseDialogueBox();

    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));

        //Debug.Log("unlocking cursor");
        CamMove = false; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            Utterance dialogue = dialogueObject.Dialogue[i];

            if (dialogue.Speaker == "RJH")
            {
                //Debug.Log("speakerObj is: " + speakerObj);
                speakerObj.sprite = rjhImage;
            } 
            else if (dialogue.Speaker == "PA")
            {
                speakerObj.sprite = paImage;
                //Debug.Log("uoahd");
            }
               //better way to do this? currently all images must be loaded into this UI script, feels ineffiecient as 
               // its also referenced int the utterance class 

            yield return RunTypingEffect(dialogue.Spoke);

            textLabel.text = dialogue.Spoke;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasReponses) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasReponses)
        {
            //Debug.Log("responding");
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            Debug.Log("Steppin");
            CloseDialogueBox();
            Debug.Log("locking cursor");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textLabel);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                typewriterEffect.Stop();
            }
        }
    }

    private void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        CamMove = true;
    }

     
        /*if (playerCam.name.Contains("Bob"))
        (
            return "boob";
        )*/
    
}
