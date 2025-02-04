using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private void Awake()
    {
 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointerdown");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointerup");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //empty
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //empty
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //empty
    }
}
