using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableInt
{
    private int value;

    virtual public int Value
    {
        get { return value; }
        set
        {
            if (this.value != value)
            {
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }

    public event System.Action<int> OnValueChanged;

    public ObservableInt(int value)
    {
        this.value = value;
    }
}