using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] Transform InventoryParent;
    InventorySlot[] slots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;
        slots = InventoryParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                Debug.Log(inventory.items[i].name);
                slots[i].AppendItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearItem();
            }
        }
    }
}
