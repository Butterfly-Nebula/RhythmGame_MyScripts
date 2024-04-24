using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HoldNote
{
    public string type;
    public int holdID;
    public float timeHolding;
    public float beatTime;
    public float spawnTime;
    public Vector3 position;
    public int maxScore;
}
