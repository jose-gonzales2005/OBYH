using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    public PlayerMove player;
    public bool inCollider = false;

    void Start()
    {
        GameObject playa = GameObject.Find("PlayerObject");
        player = playa.GetComponent<PlayerMove>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GameObject collidier = GameObject.Find(this);
            //currentCollider.GetComponent<Collider>();
            Debug.Log("entering collider: " + this);
            inCollider = true;
            player.Interactable = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log(player.Interactable);
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                Debug.Log("exiting collider: " + this);
                player.Interactable = null;
                inCollider = false;
            }
        }
    }


    public void Interact(PlayerMove player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }

    /*public void OnMouseDown() 
    {
        if (inCollider)
            player.Interactable = this;            
    }

    public void OnMouseUp()
    {  
        Debug.Log("mouse up");
        player.Interactable = null;
    }*/
}
