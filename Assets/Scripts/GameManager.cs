using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FieldBuilder fieldBuilder;
    public GameField gameField;

    private void Start() 
    {
        gameField.Init(new Vector2Int(3, 3));
        fieldBuilder.Init(gameField);
        fieldBuilder.Build();
    }
    
    
}
