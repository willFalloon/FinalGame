using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EatDrop : MonoBehaviour, IDropHandler
{
    public bool isUnhealthy = false;
    public bool isHealthy = false;
    public GameObject twoX;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            
        }
        if (twoX != null && isUnhealthy)
        {
            GameObject spawnedtwoX = Instantiate(twoX, transform.position, Quaternion.identity);
            spawnedtwoX.transform.SetParent(transform, false);
        }

    }


}