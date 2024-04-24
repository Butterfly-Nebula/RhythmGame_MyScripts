using System.Collections;
using System.Collections.Generic;
using System.Diagnostics; // Microsoft C# :>
using UnityEngine;
using System;
using System.Linq;

public class BeatmapScript : MonoBehaviour
{
    // Sound
    [SerializeField] private TextAsset beatmapFile; // reference to the text file
    [SerializeField] private AudioSource audioSource;

    public Stopwatch stopwatch; // for the song

    // array where the key times will be added to
    [SerializeField] private string[] readLines;
    List<int> timeStamps = new List<int>(); // make a list where the final conversion will be added

    [SerializeField] private GameObject button;
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject holdButton;

    private int noteIndex;
    [SerializeField] private GameObject canvas;
    private GameObject newCanvas;

    //[SerializeField] public GameObject[] myTapNotes; // make an array with the prefabs for the tap notes
    public int numSpawned = 0; // the number of objects spawned
    private int tapNoteNum = 0;
    private int sliderNum = 0;
    private int holdNum = 0;

    public float maxScore;
    public float possibleScore;

    private void Awake()
    {
        maxScore = 1;
        possibleScore = 0.001f;
    }

    void Start()
    {
        noteIndex = 0;

        stopwatch = new Stopwatch();

        newCanvas = Instantiate(canvas) as GameObject;

        // checks if the beatmap txt file is assigned
        if (beatmapFile != null)
        {
            ReadTextAsset();
            PlayAudio();
        }
        else
        {
            UnityEngine.Debug.LogError("Beatmap file is NOT assigned!");
        }
    }

    void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            stopwatch.Start();
        }
        else
        {
            UnityEngine.Debug.LogError("AudioSource is NOT assigned!");
        }
    }

    private void Update()
    {
        if (CodeBeatMap(beatmapFile.text))
        {
            // sgsht
        }
    }


    bool CodeBeatMap(string beatmapText)
    {
        float newTiming = stopwatch.ElapsedMilliseconds;
        NoteLoader theList = gameObject.GetComponent<NoteLoader>();
        SliderLoader theSliderList = gameObject.GetComponent<SliderLoader>();
        HoldLoader theHoldList = gameObject.GetComponent<HoldLoader>();

        if (noteIndex < timeStamps.Count && newTiming >= timeStamps[noteIndex] - 400 && newTiming <= timeStamps[noteIndex] - 200)
        {
            //UnityEngine.Debug.Log($"time: {stopwatch.ElapsedMilliseconds} and counter: {elementNum}");
            if ((newTiming >= timeStamps[2] - 400 && newTiming <= timeStamps[2] - 200)
                || (newTiming >= timeStamps[7] - 400 && newTiming <= timeStamps[7] - 200)
                || (newTiming >= timeStamps[10] - 400 && newTiming <= timeStamps[10] - 200)
                || (newTiming >= timeStamps[12] - 400 && newTiming <= timeStamps[12] - 200)
                || (newTiming >= timeStamps[14] - 400 && newTiming <= timeStamps[14] - 200)
                || (newTiming >= timeStamps[19] - 400 && newTiming <= timeStamps[19] - 200)
                || (newTiming >= timeStamps[21] - 400 && newTiming <= timeStamps[21] - 200)
                || (newTiming >= timeStamps[23] - 400 && newTiming <= timeStamps[23] - 200)
                || (newTiming >= timeStamps[29] - 400 && newTiming <= timeStamps[29] - 200)
                || (newTiming >= timeStamps[30] - 400 && newTiming <= timeStamps[30] - 200)
                || (newTiming >= timeStamps[34] - 400 && newTiming <= timeStamps[34] - 200)
                || (newTiming >= timeStamps[35] - 400 && newTiming <= timeStamps[35] - 200)
                || (newTiming >= timeStamps[38] - 400 && newTiming <= timeStamps[38] - 200)
                || (newTiming >= timeStamps[43] - 400 && newTiming <= timeStamps[43] - 200)
                || (newTiming >= timeStamps[51] - 400 && newTiming <= timeStamps[51] - 200))
            {
                // UnityEngine.Debug.Log($"time: {stopwatch.ElapsedMilliseconds} and counter: {tapNoteNum} and ID: {theList.tapNotesList[tapNoteNum].position}");

                Vector3 rndPos = theSliderList.tapSlidersList[sliderNum].position;

                maxScore = theSliderList.tapSlidersList[sliderNum].maxScore;

                GameObject newSlider = Instantiate(slider, rndPos, Quaternion.identity) as GameObject;
                newSlider.transform.SetParent(newCanvas.transform, false);

                numSpawned++;
                sliderNum++;
            }
            else
            {
                if ((newTiming >= timeStamps[3] - 400 && newTiming <= timeStamps[3] - 200)
                    || (newTiming >= timeStamps[5] - 400 && newTiming <= timeStamps[5] - 200)
                    || (newTiming >= timeStamps[16] - 400 && newTiming <= timeStamps[16] - 200)
                    || (newTiming >= timeStamps[24] - 400 && newTiming <= timeStamps[24] - 200)
                    || (newTiming >= timeStamps[26] - 400 && newTiming <= timeStamps[26] - 200)
                    || (newTiming >= timeStamps[32] - 400 && newTiming <= timeStamps[32] - 200)
                    || (newTiming >= timeStamps[40] - 400 && newTiming <= timeStamps[40] - 200)
                    || (newTiming >= timeStamps[41] - 400 && newTiming <= timeStamps[41] - 200)
                    || (newTiming >= timeStamps[42] - 400 && newTiming <= timeStamps[42] - 200)
                    || (newTiming >= timeStamps[45] - 400 && newTiming <= timeStamps[45] - 200)
                    || (newTiming >= timeStamps[48] - 400 && newTiming <= timeStamps[48] - 200)
                    || (newTiming >= timeStamps[50] - 400 && newTiming <= timeStamps[50] - 200))
                {
                    //UnityEngine.Debug.Log($"time: {stopwatch.ElapsedMilliseconds} and counter: {holdNum} and ID: {theHoldList.holdNotesList[holdNum].position}");

                    Vector3 rndPos = theHoldList.holdNotesList[holdNum].position;

                    maxScore = theHoldList.holdNotesList[holdNum].maxScore;

                    GameObject newHold = Instantiate(holdButton, rndPos, Quaternion.identity) as GameObject;
                    newHold.transform.SetParent(newCanvas.transform, false);

                    numSpawned++;
                    holdNum++;
                }
                else
                {
                    if (tapNoteNum < theList.tapNotesList.Count)
                    {
                        //UnityEngine.Debug.Log($"time: {stopwatch.ElapsedMilliseconds} and counter: {tapNoteNum} and ID: {theList.tapNotesList[tapNoteNum].position}");

                        Vector3 rndPos = theList.tapNotesList[tapNoteNum].position;

                        maxScore = theList.tapNotesList[tapNoteNum].maxScore;

                        GameObject newButton = Instantiate(button, rndPos, Quaternion.identity) as GameObject;
                        newButton.transform.SetParent(newCanvas.transform, false);

                        numSpawned++;
                        tapNoteNum++;
                    }
                }
            }
            //UnityEngine.Debug.Log(numSpawned);
            possibleScore = possibleScore + maxScore;
            noteIndex++;

            return true;
        }

        return false;
    }

    void ReadTextAsset()
    {
        readLines = beatmapFile.text.Split(new string[] { "\n" }, StringSplitOptions.None); // split the data and store it in a variable

        // skip the lines until line 13
        readLines = readLines.Skip(12).ToArray();

        foreach (string readLine in readLines)
        {
            // split the lines with the format MM:SS:MSMSMS into components for each of them
            string[] components = readLine.Split(':');

            if (components.Length == 3)
            {
                // parse minutes, seconds, and milliseconds
                int minutes = int.Parse(components[0]);
                int seconds = int.Parse(components[1]);
                int milliseconds = int.Parse(components[2]);

                // convert everything to milliseconds
                int totalMilliseconds = minutes * 60 * 1000 + seconds * 1000 + milliseconds;

                // add to the list
                timeStamps.Add(totalMilliseconds);
            }
        }
    }
}
