using UnityEngine;

public class ItemPicking : MonoBehaviour
{

    [SerializeField] public item item;
    public bool PickUp(item pickedStuff, GameObject currentPlacement)
    {
        if (Inventory.instance.CheckIfAddingItemAvailable() == true)
        {
            Inventory.instance.AddItem(pickedStuff);
            currentPlacement.GetComponent<SurroundingDesc>().itemsOnTile.Remove(pickedStuff);
            return true;
        }
        else 
        {
            return false;
        }
        
    }
}
