using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndVideo : MonoBehaviour
{
    public string EarGameplay;

    void Start()
    {

        Invoke(nameof(LoadGameScene), 10f);
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene(EarGameplay);
    }
}
