using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class GameField : MonoBehaviour
{
    public TextMeshProUGUI moneyValue;
    private Vector2Int _fieldSize;
    private List<FieldCell> _cells;
    private bool _gettingMoney;
    public PlayerStats stats;


    public Vector2Int FieldSize
    {
        get => _fieldSize;
    }

    public List<FieldCell> Cells
    {
        get => _cells;
    }


    public void Init(Vector2Int size)
    {
        _fieldSize = size;
        _gettingMoney = true;
        _cells = new List<FieldCell>();
        for (int i = 0; i < _fieldSize.x; i++)
        {
            for (int j = 0; j < _fieldSize.y; j++)
            {
                FieldCell newFieldCell = new FieldCell(new Vector2Int(i, j), new MinMaxInt(-1, -1, 10));
                _cells.Add(newFieldCell);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            GetCellWithState(-1).State.Value++;
        }

        stats.OnValueReset += SpawnNewBuilding;

        _gettingMoney = true;
        StartCoroutine(GenerateMoney());
    }

    public FieldCell GetCellWithState(int state)
    {
        var rand = new System.Random();
        var chosenCells = _cells.Where(cell => cell.State.Value == state);
        return chosenCells.Skip(rand.Next(chosenCells.Count())).FirstOrDefault();
    }

    IEnumerator GenerateMoney()
    {
        while (_gettingMoney)
        {
            yield return new WaitForSeconds(1);
            foreach (var cell in _cells)
            {
                if (cell.State.Value > 0)
                {
                    stats.Money += (int)Mathf.Pow(2, cell.State.Value);
                    moneyValue.text = stats.Money.ToString();
                }
            }
        }
    }


    public void SpawnNewBuilding()
    {
        FieldCell cell = GetCellWithState(0);
        if (cell != null)
        {
            cell.State.Value++;
        }
    }
}