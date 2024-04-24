using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLoader : MonoBehaviour
{
    public List<TapNote> tapNotesList;
    public Dictionary<int, TapNote> tapNotes;

    void Start()
    {
        tapNotes = new Dictionary<int, TapNote>();
        TapNoteDictionary dictionary = JsonUtility.FromJson<TapNoteDictionary>(JsonFileReader.LoadJsonAsResource("TapNoteDictionary.txt"));
        foreach (string dictionaryTapNote in dictionary.tapNotes)
        {
            LoadTapNote(dictionaryTapNote);
        }

        foreach (KeyValuePair<int, TapNote> entry in tapNotes)
        {
            TapNote temp = entry.Value;
            tapNotesList.Add(temp);
        }
    }

    public void LoadTapNote(string path)
    {
        string myLoadedTapNote = JsonFileReader.LoadJsonAsResource(path);
        TapNote myTapNote = JsonUtility.FromJson<TapNote>(myLoadedTapNote);

        if(tapNotes.ContainsKey(myTapNote.noteID))
        {
            Debug.LogWarning("Note " + myTapNote.beatTime + " Key already exists as " + tapNotes[myTapNote.noteID].beatTime);
        } else
        {
            tapNotes.Add(myTapNote.noteID, myTapNote);
        }
    }
}
