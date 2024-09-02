using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private CanvasScaler canvasScaler;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        GameObject Canvas = GameObject.FindWithTag("CanvasTag");
        if (Canvas == null)
        {
            Debug.LogError("Canvas with tag 'CanvasTag' not found.");
            return;
        }

        CanvasScaler canvasScaler = Canvas.GetComponent<CanvasScaler>();
        if (canvasScaler == null)
        {
            Debug.LogError("CanvasScaler component not found on the Canvas.");
            return;
        }

        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / (canvasScaler.scaleFactor * 1.6f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        GameObject dropTarget = eventData.pointerCurrentRaycast.gameObject;
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        if (dropTarget != null && dropTarget.GetComponent<BinDrop>() || dropTarget.GetComponent<EatDrop>() != null)
        {

        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");


    }

}