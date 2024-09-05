using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EatDrop : MonoBehaviour, IDropHandler
{

    public float lowerRangeX = 0;
    public float upperRangeX = 0;
    public float lowerRangeY = 0;
    public float upperRangeY = 0;
    public PointCounter pointCounter;
    public GameObject twoX;
    Quaternion randomRotation = Random.rotation;

    public float onScreenTime = 2.0f;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition * 1000f;
        

        if (eventData.pointerDrag.CompareTag("Unhealthy"))
        {
            pointCounter.AddPoints(5);

            if (twoX != null)
            {
                Vector3 randomPosition = new Vector3(
                    transform.position.x + Random.Range(lowerRangeX, upperRangeX),
                    transform.position.y + Random.Range(lowerRangeY, upperRangeY));



                GameObject spawnedtwoX = Instantiate(twoX, randomPosition, Random.rotation);

                float randomScale = Random.Range(0.2f, 0.7f);
                spawnedtwoX.transform.SetParent(transform, false);
                spawnedtwoX.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            }
        }

    }








}