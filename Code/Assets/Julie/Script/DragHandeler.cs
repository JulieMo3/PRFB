﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedObject;
    Vector3 Startpos;
    Transform StartParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedObject = gameObject;
        Startpos = transform.position;
        StartParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedObject = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == StartParent)
        {
            transform.position = Startpos;
        }
        
    }
}
