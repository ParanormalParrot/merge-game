using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildPointsView : MonoBehaviour
{
    public Slider slider;

    public TextMeshProUGUI text;

    public PlayerStats stats;

    void Start()
    {
        slider.maxValue = 5;
        stats.OnValueChanged += UpdateValues;
    }

    private void UpdateValues(int value)
    {
        slider.value = value;
        text.text = value.ToString();
    }

    public void ButtonPress()
    {
        stats.Points++;
    }
}