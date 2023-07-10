using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class GameField : MonoBehaviour
{
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEMS;
    public int Y_SPACE_BETWEEN_ITEMS;
    public List<FieldCell> cells;
    public Vector2Int fieldSize;
    private GameObject selectedObject;
    public CellView cellPrefab;
    public TextMeshProUGUI moneyValue;
    private void Start()
    {
        cells = new List<FieldCell>();
        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                CellView newCellView = Instantiate(cellPrefab, Vector3.zero, Quaternion.identity, transform);
                FieldCell newFieldCell = new FieldCell(new Vector2Int(i, j), new MinMaxInt(0, 0, 10));
                newCellView.Init(newFieldCell);
                newCellView.transform.localPosition = GetPosition(i, j);
                cells.Add(newFieldCell);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            GetCellWithState(0).State.Value++;
        }

        PlayerStats.OnValueReset += SpawnNewBuilding;

        StartCoroutine(GenerateMoney());
    }
    
    public FieldCell GetCellWithState(int state)
    {
        var rand = new System.Random();
        var chosenCells = cells.Where(cell => cell.State.Value == state);
        return chosenCells.Skip(rand.Next(chosenCells.Count())).FirstOrDefault();
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            foreach (var cell in cells)
            {
                cell.GenerateMoney();
                moneyValue.text = PlayerStats.Money.ToString();
            }
        }
    }

    public Vector3 GetPosition(int i, int j)
    {
        return new Vector3(X_START + X_SPACE_BETWEEN_ITEMS * i,
            Y_START + -Y_SPACE_BETWEEN_ITEMS * j, 0f);
    }

    public void SpawnNewBuilding()
    {
        GetCellWithState(0).State.Value++;
    }
}