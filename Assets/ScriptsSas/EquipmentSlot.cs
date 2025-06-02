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
    public TextMeshProUGUI ammountOfItems;
    public GameObject ammountOnItem;
    public item itemInSlot;
public void AppendItem(item newItem, int index) 
    {
        itemInSlot = newItem;
        ammount = itemInSlot.numberOfItems;
        item = newItem;
        icon.sprite = item.icon;    
        icon.enabled = true;

    }
    public void ClearItem()
    {
        item = null;
        icon.sprite = null;
        itemInSlot = null;
        ammount = 0;
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
