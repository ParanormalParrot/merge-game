using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player Stats", menuName = "Player Stat")]
public class PlayerStats : ScriptableObject
{
    private int _money;
    private int _points;

    public event Action<int> OnValueChanged;
    public event Action OnValueReset;


    private void OnEnable()
    {
        OnValueChanged = null;
        OnValueReset = null;
        _money = 0;
        _points = 0;
    }


    public int Money
    {
        get => _money;
        set => _money = value;
    }


    public int Points
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