using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableInt
{
    private int _value;

    virtual public int Value
    {
        get { return _value; }
        set
        {
            if (_value != value)
            {
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }

    public event Action<int> OnValueChanged;

    public ObservableInt(int value)
    {
        _value = value;
    }
}