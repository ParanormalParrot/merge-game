using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FieldBuilder : MonoBehaviour
{
    public int x_start;
    public int y_start;
    public int x_space_between_items;
    public int y_space_between_items;
    public CellView cellPrefab;
    private GameField _gameField;


    public void Init(GameField gameField)
    {
        _gameField = gameField;
    }

    public void Build()
    {
        for (int i = 0; i < _gameField.FieldSize.x; i++)
        {
            for (int j = 0; j < _gameField.FieldSize.y; j++)
            {
                CellView newCellView = Instantiate(cellPrefab, Vector3.zero, Quaternion.identity, transform);
                newCellView.Init(_gameField.Cells[j * _gameField.FieldSize.x + i]);
                newCellView.transform.localPosition = GetPosition(i, j);
            }
        }
    }

    public Vector3 GetPosition(int i, int j)
    {
        return new Vector3(x_start + x_space_between_items * i,
            y_start + -y_space_between_items * j, 0f);
    }
}