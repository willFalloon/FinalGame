using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerMiddleTop : MonoBehaviour
{
    public GameObject[] foodItems;  // Ensure these are UI elements with RectTransform
    public float spawnRangeX = 20;
    public float spawnPosY = 20;
    public float spawnPosX = 20;
    private RectTransform canvas;  // Reference to the Canvas RectTransform
    public bool plsWork = true;
    public float foodMax = 0;

    void Start()
    {
        // Find the Canvas in the scene and assign it
        canvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
        InvokeRepeating("SpawnFood", 0.0f, 0.01f);

        if (canvas == null)
        {
            Debug.LogError("Canvas not found in the scene. Make sure there is a Canvas present.");
        }
    }

    void Update()
    {
        // You can add update logic here if needed
    }

    void SpawnFood()
    {
        if (foodMax >= 30)
        {
            CancelInvoke("SpawnFood");
            return;
        }

        Vector3 spawnPos = new Vector3
            (
            Random.Range(-spawnRangeX, spawnRangeX) + spawnPosX,

            spawnPosY, 0
            );

        int foodIndex = Random.Range(0, foodItems.Length);
        GameObject spawnedItem = Instantiate(foodItems[foodIndex]);

        // Set the parent to the Canvas RectTransform
        if (canvas != null)
        {
            RectTransform spawnedRectTransform = spawnedItem.GetComponent<RectTransform>();
            if (spawnedRectTransform != null)
            {
                spawnedRectTransform.SetParent(canvas, false);
                spawnedRectTransform.anchoredPosition = spawnPos; // Set the UI position
            }
            else
            {
                Debug.LogError("Spawned item does not have a RectTransform component.");
            }
        }

        foodMax++;
    }
}