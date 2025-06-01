using UnityEngine;

public class ItemPicking : MonoBehaviour
{

    [SerializeField] public item item;
    public bool PickUp(item pickedStuff, GameObject currentPlacement)
    {
        if (Inventory.instance.CheckIfAddingItemAvailable() == true)
        {
            Inventory.instance.AddItem(pickedStuff);
            SurroundingDesc currentTile = currentPlacement.GetComponent<SurroundingDesc>();
            if (currentTile.ammountOfItemOnTile == 1)
            {
                currentTile.itemsOnTile.Remove(pickedStuff);
            }
            else
            {
                if (currentTile.ammountOfItemOnTile-1 > 0)
                {
                    currentTile.ammountOfItemOnTile--;
                }
                else
                {
                    return false;
                }

            }


                return true;
        }
        else 
        {
            return false;
        }
        
    }
}
