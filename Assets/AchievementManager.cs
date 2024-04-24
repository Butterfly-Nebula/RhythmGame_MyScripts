using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static List<Achievement> achievements = new List<Achievement>();


    public ScoreScript scoreScript; // Reference to your ScoreScript

    // Add a new static variable to keep track of drag count
    private static int dragCount;

    private void Start()
    {
        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        if (achievements != null)
            return;

 
        achievements.Add(new Achievement("High Scorer", "Achieve a score over 10 points.", (object o) => scoreScript.finalScore > 10));
        // Add the "Received First Instrument" achievement
        achievements.Add(new Achievement("Received First Instrument", "Receive your first instrument.", (object o) => false));
        // Add the "Robin Hood is that you?" achievement
        achievements.Add(new Achievement("Robin Hood is that you?", "Achieve an accuracy above 5%.", (object o) => (float)o > 5f));
        // Add the "Drag me to victory!" achievement
        achievements.Add(new Achievement("Drag me to victory!", "Complete 2 drags.", (object o) => dragCount >= 2));
    }

    private void Update()
    {
        CheckAchievementCompletion();
    }

    private void CheckAchievementCompletion()
    {
        if (achievements == null)
            return;

        foreach (var achievement in achievements)
        {
            achievement.UpdateCompletion();
        }
    }

    // Static method to notify the AchievementManager about the accuracy
    public static void NotifyAccuracy(float accuracy)
    {
        if (achievements == null)
            return;

        // Check if the "Robin Hood is that you?" achievement is already achieved
        Achievement robinHoodAchievement = achievements.Find(a => a.title == "Robin Hood is that you?");

        if (robinHoodAchievement == null || !robinHoodAchievement.achieved)
        {
            // If not achieved, set it as achieved and log the achievement
            robinHoodAchievement = new Achievement("Robin Hood is that you?", "Achieve an accuracy above 5%.", (object o) => accuracy > 5f);
            robinHoodAchievement.achieved = true;
            //Debug.Log($"{robinHoodAchievement.title}: {robinHoodAchievement.description}");
        }
    }

    // Static method to notify the AchievementManager about receiving the first instrument
    public static void NotifyInstrumentReceived()
    {
        if (achievements == null)
            return;

        // Check if the "Received First Instrument" achievement is already achieved
        Achievement receivedFirstInstrumentAchievement = achievements.Find(a => a.title == "Received First Instrument");

        if (receivedFirstInstrumentAchievement == null || !receivedFirstInstrumentAchievement.achieved)
        {
            // If not achieved, set it as achieved and log the achievement
            receivedFirstInstrumentAchievement = new Achievement("Received First Instrument", "Receive your first instrument.", (object o) => true);
            receivedFirstInstrumentAchievement.achieved = true;
            Debug.Log($"{receivedFirstInstrumentAchievement.title}: {receivedFirstInstrumentAchievement.description}");
        }
    }

    // Static method to notify the AchievementManager about drag count
    public static void NotifyDragCount(int count)
    {
        // Update the static drag count variable
        dragCount = count;

        if (achievements == null)
            return;

        // Check if the "Drag me to victory!" achievement is already achieved
        Achievement dragAchievement = achievements.Find(a => a.title == "Drag me to victory!");

        if (dragAchievement == null || !dragAchievement.achieved)
        {
            // If not achieved, set it as achieved and log the achievement
            dragAchievement = new Achievement("Drag me to victory!", "Complete 2 drags.", (object o) => dragCount >= 2);
            dragAchievement.achieved = true;
            //Debug.Log($"{dragAchievement.title}: {dragAchievement.description}");
        }
    }
}

public class Achievement
{
    public Achievement(string title, string description, Predicate<object> requirement)
    {
        this.title = title;
        this.description = description;
        this.requirement = requirement;
    }

    public string title;
    public string description;
    public Predicate<object> requirement;

    public bool achieved;

    public void UpdateCompletion()
    {
        if (achieved)
            return;

        if (RequirementsMet())
        {
            Debug.Log($"{title}: {description}");
            achieved = true;
        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}
