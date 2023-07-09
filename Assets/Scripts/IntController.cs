using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntController : MonoBehaviour
{
    public InputField inputField;
    public ValueVisual valueVisual;

    private MinMaxInt minMaxInt;

    private void Start()
    {
        minMaxInt = new MinMaxInt(0, 0, 10);
        valueVisual.Init(minMaxInt);
    }

    public void UpdateValue()
    {
        if (int.TryParse(inputField.text, out int newValue))
        {
            minMaxInt.Value = newValue;
        }
    }
}