using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntController : MonoBehaviour
{
    public InputField inputField;
    public ValueVisual valueVisual;

    private MinMaxInt _minMaxInt;

    private void Start()
    {
        _minMaxInt = new MinMaxInt(0, 0, 10);
        valueVisual.Init(_minMaxInt);
    }

    public void UpdateValue()
    {
        if (int.TryParse(inputField.text, out int newValue))
        {
            _minMaxInt.Value = newValue;
        }
    }
}