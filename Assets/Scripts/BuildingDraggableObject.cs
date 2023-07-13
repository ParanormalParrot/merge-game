using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingDraggableObject : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 _offset;
    private CellView _hoverCell;
    public CellView cell;

    private void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        }
    }

    private void OnMouseDown()
    {
        _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        if (_hoverCell != null && cell != _hoverCell && cell.fieldCell.State.Value == _hoverCell.fieldCell.State.Value)
        {
            cell.fieldCell.State.Value = 0;
            _hoverCell.fieldCell.State.Value++;
        }

        transform.position = cell.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Cell"))
        {
            _hoverCell = col.GetComponentInChildren<CellView>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Cell") && dragging)
        {
            _hoverCell = null;
        }
    }
}