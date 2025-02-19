using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Color startcolor;
    void Start()
    {
        Debug.Log("is this thing on");
    }

    // Update is called once per frame
    void Update()
    {

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
