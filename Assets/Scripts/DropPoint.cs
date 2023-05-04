using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPoint : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject correctDrop;
    public bool isCorrect = false;
    public TrickCheck trickCheck;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && correctDrop == null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DragDrop>().isLocked = true;
            eventData.pointerDrag.GetComponent<DragDrop>().Unlock();
        }
        else if (eventData.pointerDrag == correctDrop)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DragDrop>().isLocked = true;
            isCorrect = true;
            trickCheck.checkComplete();
        }
    } 
}
