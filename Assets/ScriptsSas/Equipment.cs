using Unity.VisualScripting;

using UnityEngine;

using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Equipment : MonoBehaviour
{
    Inventory inventory;

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;

    [SerializeField] private GameObject EquipmentActions;

    [SerializeField] private GameObject EquipmentLayout;

    [SerializeField] private GameObject InventoryActions;
    [SerializeField] public Button examine;
    [SerializeField] public Button deEquip;

    EquipmentSlot[] childrenOfLayout;
    public int numOfSlots;
    public static Equipment instance;
    public item[] currentEquipment;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("You fucked up with inventory singletone");
            return;
        }
        instance = this;
    }

    
    private void Start()
    {
        inventory = Inventory.instance;
        numOfSlots = System.Enum.GetNames(typeof(EquimpentSlot)).Length;
        currentEquipment = new item[numOfSlots];

        childrenOfLayout = EquipmentLayout.GetComponentsInChildren<EquipmentSlot>();

        for (int i = 0; i < numOfSlots; i++)
        {
            childrenOfLayout[i].indexer = i;
        }
    }

    public void showItem(int index)
    {

        //Отключение кнопок при выборе другого предмета
        #region 
        if (currentEquipment[index] != null)
        {

            InventoryActions.SetActive(false);
            EquipmentActions.SetActive(true);
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

        inventory.Name.text = currentEquipment[index].name;
        inventory.Description.text = currentEquipment[index].description;
        inventory.Icon.sprite = currentEquipment[index].icon;

        //Кнопки, которые всегда показываются в интерфейсе
        examine.interactable = true;
        deEquip.interactable = true;

    }
}
