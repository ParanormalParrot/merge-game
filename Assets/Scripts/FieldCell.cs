using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCell
{
    private Vector2Int _position;
    private MinMaxInt _state;

    public FieldCell(Vector2Int position, MinMaxInt state)
    {
        _position = position;
        _state = state;
    }

    public Vector2Int Position
    {
        get => _position;
    }

    public MinMaxInt State
    {
        get => _state;
    }
    
}