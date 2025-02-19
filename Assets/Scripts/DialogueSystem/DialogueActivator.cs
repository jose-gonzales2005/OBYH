using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    public PlayerMove player;
    private bool inCollider = false;
    public Color startcolor;

    void Start()
    {
        GameObject playa = GameObject.Find("PlayerObject");
        player = playa.GetComponent<PlayerMove>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                inCollider = false;
            }
        }
    }


    public void Interact(PlayerMove player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }

    public void OnMouseDown() 
    {
        if (inCollider)
            player.Interactable = this;            
    }

    public void OnMouseUp()
    {   
        player.Interactable = null;
    }

    public void OnMouseEnter()
    {
        Debug.Log("Mouse entered, changing color");
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }
}
