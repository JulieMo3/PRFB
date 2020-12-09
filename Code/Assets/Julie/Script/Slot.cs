using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{

  
    protected GameObject _item;
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

        protected set
        {
            _item = value;
        }
    }
   

    public void OnDrop(PointerEventData eventData)
    {
        if (!Item )
        {
            //Item = DragHandeler.DraggedObject;
            Debug.Log(Item);
            DragHandeler.DraggedObject.transform.SetParent(transform);
           
            
            /*if (this.tag == "test")
            {
                itemID = 5;

            }*/
            
        }
    }

   
}

