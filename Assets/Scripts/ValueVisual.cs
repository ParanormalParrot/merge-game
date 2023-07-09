using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueVisual : MonoBehaviour
{
    public Text valueText;

    public void Init(ObservableInt observableInt)
    {
        observableInt.OnValueChanged += UpdateView;
    }

    private void UpdateView(int value)
    {
        valueText.text = value.ToString();
    }
}