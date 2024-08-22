using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BinDrop : MonoBehaviour, IDropHandler
{
    public GameObject twoX;
    Quaternion randomRotation = Random.rotation;

    public float onScreenTime = 2.0f;
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

        }
        if (twoX != null)
        {
            Vector3 randomPosition = new Vector3(
            transform.position.x + Random.Range(-600f, -100f),
            transform.position.y + Random.Range(-300f, 100f));



            GameObject spawnedtwoX = Instantiate(twoX, randomPosition, Random.rotation);

            float randomScale = Random.Range(0.2f, 0.7f);
            spawnedtwoX.transform.SetParent(transform, false);
            spawnedtwoX.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        }

    }


}