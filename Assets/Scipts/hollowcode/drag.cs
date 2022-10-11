using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class drag : MonoBehaviour, IDragHandler
{
    RectTransform current;

    void Awake()
    {
        current = GetComponent<RectTransform>();
    }


    public void OnDrag(PointerEventData eventData)
    {
        current.anchoredPosition += eventData.delta;
    }

}
