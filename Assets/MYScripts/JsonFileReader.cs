using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonFileReader : MonoBehaviour
{
    public static string LoadJsonAsResource(string path)
    {
        string jsonFilePath = path.Replace(".txt", "");
        TextAsset loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
        return loadedJsonfile.text;
    }
}
