using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;
    float xRotation;
    float yRotation;
    public DialogueUI dialogUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameObject canvas = GameObject.Find("DialogCanvas");
        dialogUI = canvas.GetComponent<DialogueUI>();
    }


    // Update is called once per frame
    void Update()
    {
        if (dialogUI.CamMove)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);

            if (Input.GetMouseButtonDown(0))
            {
                RayCheck();
            }
        }
    }


    public bool RayCheck()
    {
        LayerMask mask = LayerMask.GetMask("Interactable");
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            Transform objectHit = hit.transform;
            // Do something with the object that was hit by the raycast.
            return true;
        }

        return false;
    }
}
