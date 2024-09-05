using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField] PointHUD pointHUD;
    public int allPoints;
    public GameObject score;
    private TMP_Text scoreText;
    public void Start()
    {
        scoreText = score.GetComponent<TMP_Text>();
        PlayerPrefs.SetString("currentScore", "0");
        Invoke(nameof(Scoring), 45f);
        Invoke(nameof(LoadGameScene), 45.2f);
    }



    public void AddPoints(int points)
    {


        pointHUD.Points += points;
        int currentScore;
        int.TryParse(scoreText.text, out currentScore);
        currentScore += 1;
        scoreText.text = currentScore.ToString();
    }

    public void Scoring()
    {

        PlayerPrefs.SetString("currentScore", scoreText.text);

    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("FinalScene");
    }
}