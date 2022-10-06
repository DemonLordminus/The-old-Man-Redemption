using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Green : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform originalParent;
    public bool Isgreen;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.parent.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Isgreen = false;
        try
        {
            if (eventData.pointerCurrentRaycast.gameObject.layer == 3)
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "TraggerNum")
            {
                if (eventData.pointerCurrentRaycast.gameObject.name == "1")
                { Isgreen = true; }
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "None")//ÐÞ¸´ÏÔÊ¾bug
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//ÍË³ö
            }
            if(eventData.pointerCurrentRaycast.gameObject.tag == "Grid"||eventData.pointerCurrentRaycast.gameObject.tag=="Grid1")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
        catch
        { }
            transform.parent = originalParent;
            transform.position = originalParent.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }


}
