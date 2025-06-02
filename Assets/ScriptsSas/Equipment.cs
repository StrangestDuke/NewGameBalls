using Unity.VisualScripting;
using UnityEngine;

public class Equipment : MonoBehaviour
{


    public static Equipment instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("You fucked up with inventory singletone");
            return;
        }
        instance = this;
    }

    item[] currentEquipment;
    private void Start()
    {
        int numOfSlots = System.Enum.GetNames(typeof(EquimpentSlot)).Length;
        currentEquipment = new item[numOfSlots];
    }

    public void Equip(item newItem)
    {
        int slotIndex = (int)newItem.partOfBody;

        currentEquipment[slotIndex] = newItem;
    }

    public void DeEquip(item newItem)
    {
        int slotIndex = (int)newItem.partOfBody;

        currentEquipment[slotIndex] = null;
    }

}
