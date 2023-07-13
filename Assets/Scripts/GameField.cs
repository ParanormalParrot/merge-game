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
    public int x_start;
    public int y_start;
    public int x_space_between_items;
    public int y_space_between_items;
    public CellView cellPrefab;
    public TextMeshProUGUI moneyValue;
    public Vector2Int fieldSize;
    private List<FieldCell> _cells;
    private GameObject _selectedObject;
    private bool _gettingMoney;

    
    private void Start()
    {
        _cells = new List<FieldCell>();
        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                CellView newCellView = Instantiate(cellPrefab, Vector3.zero, Quaternion.identity, transform);
                FieldCell newFieldCell = new FieldCell(new Vector2Int(i, j), new MinMaxInt(-1, -1, 10));
                newCellView.Init(newFieldCell);
                newCellView.transform.localPosition = GetPosition(i, j);
                _cells.Add(newFieldCell);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            GetCellWithState(-1).State.Value++;
        }

        PlayerStats.OnValueReset += SpawnNewBuilding;

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
                cell.GenerateMoney();
                moneyValue.text = PlayerStats.Money.ToString();
            }
        }
    }

    public Vector3 GetPosition(int i, int j)
    {
        return new Vector3(x_start + x_space_between_items * i,
            y_start + -y_space_between_items * j, 0f);
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