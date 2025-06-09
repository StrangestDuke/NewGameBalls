using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Search;

public class EquipmentSlot : MonoBehaviour
{
    public int indexer = 0;
    item item;
    public Image icon;

    public int ammount;
    public item itemInSlot;
public void AppendItem(item newItem) 
    {
        itemInSlot = newItem;
        item = newItem;
        icon.sprite = item.icon;    
        icon.enabled = true;

    }
    public void ClearItem()
    {
        item = null;
        icon.sprite = null;
        itemInSlot = null;
        icon.enabled = false;

    }

    public void OnClickShowItem()
    {
        if (item != null)
        {
            Equipment.instance.showItem(indexer);
        }
    }
}
