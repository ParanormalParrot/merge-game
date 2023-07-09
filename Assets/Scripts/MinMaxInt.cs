using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxInt : ObservableInt
{
    private int minValue;
    private int maxValue;

    override public int Value
    {
        get { return base.Value; }
        set
        {
            int clampedValue = Mathf.Clamp(value, minValue, maxValue);
            base.Value = clampedValue;
        }
    }

    public MinMaxInt(int value, int minValue, int maxValue) : base(value)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
    }
}