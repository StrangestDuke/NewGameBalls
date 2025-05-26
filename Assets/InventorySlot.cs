using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public int indexer = 0;
    item item;
    public Image icon;
    int ammount; 
    public void AppendItem(item newItem, int index) 
    {
        indexer = index;
        item = newItem;
        icon.sprite = item.icon;    
        icon.enabled = true;

    }
    public void ClearItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

    }

    public void OnClickShowItem()
    {
        if (item != null)
        {
            Inventory.instance.showItem(indexer);
        }
    }
}
