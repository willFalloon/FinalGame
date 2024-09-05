using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreHandler : MonoBehaviour
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
            int finalScore = 100 - score;
            currentScoreText.text = finalScore.ToString();
        }


    }
}