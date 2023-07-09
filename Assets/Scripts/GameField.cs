using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
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
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    public FieldCell GetCellWithState(int state)
    {
        return cells.FirstOrDefault(cell => cell.State.Value == state);
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            foreach (var cell in cells)
            {
                cell.GenerateMoney();
            }
        }
    }

    public Vector3 GetPosition(int i, int j)
    {
        return new Vector3(X_START + X_SPACE_BETWEEN_ITEMS * i,
            Y_START + -Y_SPACE_BETWEEN_ITEMS * j, 0f);
    }
}