using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingDraggableObject : MonoBehaviour
{
    public bool dragging = false;
    private Vector3 offset;
    public CellView cell;
    public CellView howerCell;

    private void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
        
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        if (howerCell != null && cell != howerCell && cell.fieldCell.State.Value == howerCell.fieldCell.State.Value)
        {
            cell.fieldCell.State.Value = 0;
            howerCell.fieldCell.State.Value++;
        }
        transform.position = cell.transform.position;
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Cell"))
        {
            howerCell = col.GetComponentInChildren<CellView>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Cell") && dragging)
        {
            howerCell = null;
        }
        
    }
}