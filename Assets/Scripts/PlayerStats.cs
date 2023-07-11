using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int _money = 0;
    private static int _points = 0;

    public static event System.Action<int> OnValueChanged;
    public static event System.Action OnValueReset;

    public static int Money
    {
        get => _money;
        set => _money = value;

    }


    public static int Points
    {
        get => _points;
        set
        {
            _points = value;
            if (_points >= 5)
            {
                _points = 0;
                OnValueReset?.Invoke();
            }

            OnValueChanged?.Invoke(_points);
        }
    }
}