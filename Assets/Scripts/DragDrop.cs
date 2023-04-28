using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField] private GameObject unlocked;
    public bool isLocked = false;

    private void Start()
    {
        if (unlocked != null)
        {
            unlocked.SetActive(false);
        }
        else
        {
            Debug.Log("No 'unlocked' GameObject set");
        }
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isLocked)
        {
            return;
        }
        // Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void Unlock()
    {
        if (unlocked != null)
        {
            unlocked.SetActive(true);
            Debug.Log("button unlocked!");
            return;
        }
        else
        {
            //Debug.Log("No 'unlocked' GameObject set");
        }
    }
}
