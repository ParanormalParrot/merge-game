using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxInt : ObservableInt
{
    private int _minValue;
    private int _maxValue;

    override public int Value
    {
        get { return base.Value; }
        set
        {
            int clampedValue = Mathf.Clamp(value, _minValue, _maxValue);
            base.Value = clampedValue;
        }
    }

    public MinMaxInt(int value, int minValue, int maxValue) : base(value)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }
}