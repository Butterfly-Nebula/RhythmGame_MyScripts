using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccuracyScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI accuracyText;

    [SerializeField] private BeatmapScript beatmapScript;

    private float accuracy = 0.0f;

    void Update()
    {
        float maxPossibleScore = beatmapScript.possibleScore;

        //Debug.Log($"accuracy: {accuracy} and maxScore: {maxPossibleScore}");

        accuracy = (gameObject.GetComponent<ScoreScript>().finalScore * 100) / maxPossibleScore;

        accuracyText.text = "Accuracy: " + accuracy.ToString("F3") + " %";

        // Notify the AchievementManager about the accuracy
        AchievementManager.NotifyAccuracy(accuracy);
    }
}
