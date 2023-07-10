using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildPointsView : MonoBehaviour
{
    public Slider slider;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 5;
        PlayerStats.OnValueChanged += UpdateValues;
    }

    private void UpdateValues(int value)
    {
        slider.value = value;
        text.text = value.ToString();
    }

    public void ButtonPress()
    {
        PlayerStats.Points+=1;
    }
    
}
