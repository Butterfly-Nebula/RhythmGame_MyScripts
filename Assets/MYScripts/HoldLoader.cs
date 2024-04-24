using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLoader : MonoBehaviour
{
    public List<HoldNote> holdNotesList;
    public Dictionary<int, HoldNote> holdNotes;

    void Start()
    {
        holdNotes = new Dictionary<int, HoldNote>();
        HoldDictionary dictionary = JsonUtility.FromJson<HoldDictionary>(JsonFileReader.LoadJsonAsResource("HoldDictionary.txt"));
        foreach (string dictionaryHoldNote in dictionary.holdNotes)
        {
            LoadHoldNote(dictionaryHoldNote);
        }

        foreach (KeyValuePair<int, HoldNote> entry in holdNotes)
        {
            HoldNote temp = entry.Value;
            holdNotesList.Add(temp);
        }
    }

    public void LoadHoldNote(string path)
    {
        string myLoadedHoldNote = JsonFileReader.LoadJsonAsResource(path);
        HoldNote myHoldNote = JsonUtility.FromJson<HoldNote>(myLoadedHoldNote);

        if (holdNotes.ContainsKey(myHoldNote.holdID))
        {
            Debug.LogWarning("Hold Note " + myHoldNote.beatTime + " Key already exists as " + holdNotes[myHoldNote.holdID].beatTime);
        }
        else
        {
            holdNotes.Add(myHoldNote.holdID, myHoldNote);
        }
    }
}
