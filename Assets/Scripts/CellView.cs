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
        UpdateView(fieldCell.State.Value);
    }

    public void UpdateView(int value)
    {
        if (value < 0)
        {
            site.color = Color.grey;
        }
        else
        {
            if (value == 0)
            {
                building.gameObject.SetActive(false);
            }
            else
            {
                building.gameObject.SetActive(true);
            }
            site.color = Color.white;
            building.transform.localScale = Vector3.one * (1 + (fieldCell.State.Value - 1) * 0.25f);
        }
    }

    
}