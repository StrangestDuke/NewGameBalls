using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] Transform InventoryParent;
    [SerializeField] Transform EquipmentParent;
    InventorySlot[] slots;
    EquipmentSlot[] equipmentSlots;
    Equipment equipment; 
    int indexer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        equipment = Equipment.instance;
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;
        slots = InventoryParent.GetComponentsInChildren<InventorySlot>();
        equipmentSlots = EquipmentParent.GetComponentsInChildren<EquipmentSlot>();
        UpdateUI(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        //Индексер идет к нулю, т.к. при его не обнулении - игра начинает хуево обращаться к ячейкам инвентаря
        indexer = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AppendItem(inventory.items[i], indexer);
                slots[i].ShowItemCount();
                indexer++;
            }
            else
            {
                slots[i].ClearItem();
            }
        }
        //Equipment UI update
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipment.currentEquipment[i] != null)
            {
                equipmentSlots[i].AppendItem(equipment.currentEquipment[i]);
            }
            else
            {
                equipmentSlots[i].ClearItem();
            }
        }
    }
}
