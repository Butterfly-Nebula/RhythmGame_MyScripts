using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI comboText;
    //[SerializeField] private ScoreScript scoreScript;

    public int counter = 0;

    private void Update()
    {
        AddCombo();
    }

    private void AddCombo()
    {
        comboText.text = "Combo: " + counter.ToString() + " x";
    }
}
