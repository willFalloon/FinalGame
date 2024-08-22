using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    public GameObject[] foodItems;  // Ensure these are UI elements with RectTransform
    public float spawnRangeX = 20;
    public float spawnPosY = 20;
    public float spawnPosX = 20;
    private RectTransform canvas;  // Reference to the Canvas RectTransform

    void Start()
    {
        // Find the Canvas in the scene and assign it
        canvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();

        if (canvas == null)
        {
            Debug.LogError("Canvas not found in the scene. Make sure there is a Canvas present.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX) + spawnPosX,
                0,
                spawnPosY
            );

            int foodIndex = Random.Range(0, foodItems.Length);
            GameObject spawnedItem = Instantiate(foodItems[foodIndex], spawnPos, Quaternion.identity);

            // Set the parent to the Canvas RectTransform
            if (canvas != null)
            {
                RectTransform spawnedRectTransform = spawnedItem.GetComponent<RectTransform>();
                if (spawnedRectTransform != null)
                {
                    spawnedRectTransform.SetParent(canvas, false);
                }
                else
                {
                    Debug.LogError("Spawned item does not have a RectTransform component.");
                }
            }
        }
    }
}