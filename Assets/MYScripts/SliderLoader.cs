using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderLoader : MonoBehaviour
{
    public List<TapSlider> tapSlidersList;
    public Dictionary<int, TapSlider> tapSliders;

    void Start()
    {
        tapSliders = new Dictionary<int, TapSlider>();
        SliderDictionary dictionary = JsonUtility.FromJson<SliderDictionary>(JsonFileReader.LoadJsonAsResource("SliderDictionary.txt"));
        foreach (string dictionarySlider in dictionary.tapSliders)
        {
            LoadSlider(dictionarySlider);
        }

        foreach (KeyValuePair<int, TapSlider> entry in tapSliders)
        {
            TapSlider temp = entry.Value;
            tapSlidersList.Add(temp);
        }
    }

    public void LoadSlider(string path)
    {
        string myLoadedSlider = JsonFileReader.LoadJsonAsResource(path);
        TapSlider mySlider = JsonUtility.FromJson<TapSlider>(myLoadedSlider);

        if (tapSliders.ContainsKey(mySlider.sliderID))
        {
            Debug.LogWarning("Slider " + mySlider.beatTime + " Key already exists as " + tapSliders[mySlider.sliderID].beatTime);
        }
        else
        {
            tapSliders.Add(mySlider.sliderID, mySlider);
        }
    }
}
