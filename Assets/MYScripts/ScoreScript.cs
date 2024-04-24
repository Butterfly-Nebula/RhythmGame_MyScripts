using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int finalScore = 0;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        AddScore();
    }

    private void AddScore()
    {
        //Debug.Log($"final score: { finalScore}");
        scoreText.text = "Score: " + finalScore.ToString();
    }
}