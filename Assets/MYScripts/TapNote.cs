using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TapNote
{
    public string type;
    public int noteID;
    public float beatTime;
    public float spawnTime;
    public Vector3 position;
    public int maxScore;
}
