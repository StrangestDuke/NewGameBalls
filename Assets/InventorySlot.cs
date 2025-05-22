using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    item item;
    public Image icon;
    
    public void AppendItem(item newItem) 
    {
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
}
