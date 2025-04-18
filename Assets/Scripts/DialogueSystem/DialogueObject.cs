using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]


public class DialogueObject : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] private Utterance[] dialogue;
    [SerializeField] private Response[] responses;

    public Utterance[] Dialogue => dialogue;

    public bool HasReponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
}
