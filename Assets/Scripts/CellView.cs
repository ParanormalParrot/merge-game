using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    public FieldCell fieldCell;
    public Image building;
    public Image site;


    public void Init(FieldCell cell)
    {
        fieldCell = cell;
        fieldCell.State.OnValueChanged += UpdateView;
    }

    public void UpdateView(int value)
    {
        if (value < 0)
        {
            site.color = Color.grey;
            building.gameObject.SetActive(false);
        }
        else
        {
            site.color = Color.white;
            building.gameObject.SetActive(true);
            building.transform.localScale = Vector3.one * (1 + (fieldCell.State.Value - 1) * 0.25f);
        }
    }

    
}