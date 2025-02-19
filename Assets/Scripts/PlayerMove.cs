using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public PlayerCam myInstance;

    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        GameObject playerCam = GameObject.Find("PlayerCamera");
        myInstance = playerCam.GetComponent<PlayerCam>();
    }

    void Update()
    {
        //pause if dialogue running
        if (dialogueUI.IsOpen) return;

        MyInput();

        //dialogue activator
        if (Input.GetMouseButtonDown(0))
        {
            if (myInstance.RayCheck())
            {
                Debug.Log("Hit");
                Interactable?.Interact(this);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            Interactable?.Interact(this);
        }


    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (moveDirection.magnitude > 0)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
            rb.drag = groundDrag;
    }
}
