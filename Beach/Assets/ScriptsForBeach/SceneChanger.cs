using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string FridgeScene;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            SceneManager.LoadScene(FridgeScene);
        }
    }
}