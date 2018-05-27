using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class Slot : MonoBehaviour, IDropHandler {

    public Animator anim;
    public string bundle;
    public GameObject item
    {
        get {
            if(transform.childCount>0)
            {
                this.gameObject.SetActive(false);
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            if (DragSelectionHandler.itemBeingDragged.tag == "box1")
            {
                if (gameObject.tag == "slot1" || gameObject.tag == "slot11")
                {
                    anim.SetTrigger("blast");
                    DragSelectionHandler.itemBeingDragged.transform.SetParent(transform);
                    ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
                }
            }
            if (DragSelectionHandler.itemBeingDragged.tag == "box2")
            {
                if (gameObject.tag == "slot2" || gameObject.tag == "slot22")
                {
                    anim.SetTrigger("blast2");
                    DragSelectionHandler.itemBeingDragged.transform.SetParent(transform);
                    ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
                }
            }
        }
    }
    #endregion
}
