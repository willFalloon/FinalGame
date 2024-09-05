using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTracker : MonoBehaviour
{
    public GameObject currentScore;
    public GameObject highScore; 

    private TMP_Text currentScoreText;
    private TMP_Text highScoreText;

    void Start()
    {
        currentScoreText = currentScore.GetComponent<TMP_Text>();

        string savedScore = PlayerPrefs.GetString("currentScore", "0");
        int score;
        if (int.TryParse(savedScore, out score))
        {
            int finalScore = 80 - score;
            currentScoreText.text = finalScore.ToString();
        }


    }
}
