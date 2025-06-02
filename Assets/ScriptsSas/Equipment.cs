using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Equipment : MonoBehaviour
{
    Inventory inventory;

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

    public item[] currentEquipment;
    private void Start()
    {
        inventory = Inventory.instance;
        int numOfSlots = System.Enum.GetNames(typeof(EquimpentSlot)).Length;
        currentEquipment = new item[numOfSlots];
    }

    public void showItem(int index)
    {
        //Отключение кнопок при выборе другого предмета
        #region 
        if (inventory.items[index] != null)
        {

            inventory.Examine.interactable = false;
            inventory.Drop.interactable = false;
            inventory.DropAll.interactable = false;
            inventory.Use.interactable = false;
            inventory.Equip.interactable = false;
            inventory.Enchant.interactable = false;
            inventory.Brew.interactable = false;
        }

        #endregion

        inventory.takenItem = currentEquipment[index];

        inventory.Name.text = inventory.takenItem.name;
        inventory.Description.text = inventory.takenItem.description;
        inventory.Icon.sprite = inventory.takenItem.icon;

        //Кнопки, которые всегда показываются в интерфейсе
        inventory.Examine.interactable = true;
        inventory.Drop.interactable = true;
        inventory.DropAll.interactable = true;

    }
}
