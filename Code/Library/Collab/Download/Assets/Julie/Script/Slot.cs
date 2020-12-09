using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
  public GameObject Item
    {
        get
        {
            if (gameObject.transform.childCount> 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!Item)
        {
            DragHandeler.DraggedObject.transform.SetParent(transform);
        }
    }
}
