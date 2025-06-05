using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Metadata;

public class Inventory : MonoBehaviour
{
    [SerializeField] public GameObject EquipmentPanel;

    [Space(10), Header("Inventory menu setup")]
    [Space(10)]

    [SerializeField] public TextMeshProUGUI Description;
    [SerializeField] public TextMeshProUGUI Name;
    [SerializeField] public Image Icon;
    //[SerializeField] private GameObject[] Buttons Examine;
    [SerializeField] public Button Examine;
    [SerializeField] public Button Use;
    [SerializeField] public Button Equip;
    [SerializeField] public Button Enchant;
    [SerializeField] public Button Drop;
    [SerializeField] public Button DropAll;
    [SerializeField] public Button Give;
    [SerializeField] public Button Brew;
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;


    [Space(10), Header("Lists menu setup")]
    [Space(10)]

    public List<item> items = new List<item>();

    [SerializeField] private GameObject EquipmentActions;
    [SerializeField] private GameObject InventoryActions; 
    [SerializeField] private GameObject InventoryLayout;

    [SerializeField] private healthBar hpBarObj;
    [SerializeField] private manaBar manaBarObj;
    [SerializeField] private hungerBar hungerBarObj;


    [Space(10), Header("Current stuff setup")]
    [Space(10)]

    //Предмет, что на данный момент "Выделен"
    public item takenItem;
    public static Inventory instance;
    public int space = 88;
    Equipment equipment;
    InventorySlot[] childrenOfLayout;
    [SerializeField] public stats statistic;

    private void Start()
    {

        equipment = Equipment.instance;
        childrenOfLayout = InventoryLayout.GetComponentsInChildren<InventorySlot>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("You fucked up with inventory singletone");
            return;
        }
        instance = this;
    }



    public bool CheckIfAddingItemAvailable()
    {
        if (items.Count >= space)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    public void AddItem(item item)
    {
     

        if (items.Contains(item) )
        {
            int indexOfItem = items.IndexOf(item);
            InventorySlot itemSlot = childrenOfLayout[indexOfItem].GetComponent<InventorySlot>();
            if (item.stackable)
            {
                itemSlot.ammount = itemSlot.ammount + 1;
                itemSlot.ShowItemCount();
            }
            else
            {
                items.Add(item);
                itemSlot.ShowItemCount();
                if (onItemChangeCallback != null)
                    onItemChangeCallback.Invoke();
            }
        }
        else
        {
            items.Add(item);
            childrenOfLayout[items.Count - 1].ShowItemCount();
            if (onItemChangeCallback != null)
                onItemChangeCallback.Invoke();
        }
    }
    public void RemoveItem(item item, bool isItEaten, bool all)
    {
        int indexOfItem = items.IndexOf(item);
        InventorySlot itemSlot = childrenOfLayout[indexOfItem].GetComponent<InventorySlot>();

        if (items.Contains(item) && !all)
        {
            if (item.stackable && itemSlot.ammount > 1)
            {
                itemSlot.ammount = itemSlot.ammount - 1;
                itemSlot.ShowItemCount();
                Defocus(isItEaten);
            }
            else
            {
                items.Remove(item);
                itemSlot.ammount = 0;
                itemSlot.ShowItemCount();
                if (onItemChangeCallback != null)
                    onItemChangeCallback.Invoke();
                //Хуйня, чтобы не было возможность использовать не существующие предметы у игрока
                Defocus(isItEaten);
            }
        }
        else
        {
            items.Remove(item);
            itemSlot.ammount = 0;
            itemSlot.ShowItemCount();
            if (onItemChangeCallback != null)
                onItemChangeCallback.Invoke();
            //Хуйня, чтобы не было возможность использовать не существующие предметы у игрока
            Defocus(isItEaten);
        }
    }

    public void Defocus(bool isItEaten)
    {
        takenItem = null;

        Name.text = "";
        //Если игрок жрет(последний предмет) - описание не убирается
        if (!isItEaten ) 
            Description.text = "";

        Icon.sprite = null;


        InventoryActions.SetActive(true);
        EquipmentActions.SetActive(false);
        Examine.interactable = false;
        Drop.interactable = false;
        DropAll.interactable = false;
        Use.interactable = false;            
        Equip.interactable = false;           
        Enchant.interactable = false;
        Brew.interactable = false;


    }

    public void showItem(int index)
    {
        //Отключение кнопок при выборе другого предмета
        #region 
        if (items[index] != null)
        {
            
            InventoryActions.SetActive(true);
            EquipmentActions.SetActive(false);
            Examine.interactable = false;
            Drop.interactable = false;
            DropAll.interactable = false;
            Use.interactable = false;
            Equip.interactable = false;
            Enchant.interactable= false;
            Brew.interactable = false;
        }

        #endregion

        takenItem = items[index];
        
        Name.text = takenItem.name;
        Description.text = takenItem.description;
        Icon.sprite = takenItem.icon;

        //Кнопки, которые всегда показываются в интерфейсе
        Examine.interactable = true;
        Drop.interactable = true;
        DropAll.interactable = true;

        //If else-ы
        #region 

        if (takenItem.edable)
        {
            Use.interactable = true;
        }

        if (takenItem.canBeWorn)
        {
            Equip.interactable = true;
        }

        if (takenItem.enchantable)
        {
            Enchant.interactable = true;
        }

        if (takenItem.brewable)
        {
            Brew.interactable = true;
        }

        #endregion

    }


    public void ExamineItem()
    {
        Description.text = takenItem.examineText + "\n";
        if (takenItem.smell != "")
        {
            Description.text += takenItem.smell;
        }
    }

    public void UseItem()
    {
        Description.text = takenItem.taste;

        statistic.takeDamageHunger(takenItem.hungerReplenish);
        statistic.takeDamageHp(takenItem.hpReplenish);
        statistic.takeDamageMana(takenItem.manaReplenish);

        manaBarObj.takeDamage(takenItem.manaReplenish);
        hpBarObj.takeDamage(takenItem.hpReplenish);
        hungerBarObj.takeDamage(takenItem.hungerReplenish);

        RemoveItem(takenItem, true, false);

    }

    public void DropItem()
    {
        SurroundingDesc currentTile = DialogManager.instance.currentPlacement.GetComponent<SurroundingDesc>();
        currentTile.DropItemInTile(takenItem);
        RemoveItem(takenItem, false, false);
    }
    public void DropAllItems()
    {
        SurroundingDesc currentTile = DialogManager.instance.currentPlacement.GetComponent<SurroundingDesc>();
        currentTile.DropItemInTile(takenItem);
        RemoveItem(takenItem, false, true);
    }

    public void EquipItem()
    {

        item oldItem = null;
        int slotIndex = (int)takenItem.partOfBody;

        if (equipment.currentEquipment[slotIndex] != null)
        {
            oldItem = equipment.currentEquipment[slotIndex];

            statistic.attraction -= oldItem.attraction;
            statistic.sexApeal -= oldItem.sexApeal;
            statistic.ergonomic -= oldItem.ergonomic;
            statistic.armor -= oldItem.armor;
            statistic.magic -= oldItem.magic;
            statistic.spikes -= oldItem.spiked;
            statistic.danger -= oldItem.danger;

            AddItem(oldItem);
        }


        statistic.attraction += takenItem.attraction;
        statistic.sexApeal += takenItem.sexApeal;
        statistic.ergonomic += takenItem.ergonomic;
        statistic.armor += takenItem.armor;
        statistic.magic += takenItem.magic;
        statistic.spikes += takenItem.spiked;
        statistic.danger += takenItem.danger;

        equipment.currentEquipment[slotIndex] = takenItem;
        RemoveItem(takenItem, false, false);
    }

    public void DeEquipItem()
    {
        item oldItem = null;
        int slotIndex = (int)takenItem.partOfBody;

        oldItem = equipment.currentEquipment[slotIndex];

        statistic.attraction -= oldItem.attraction;
        statistic.sexApeal -= oldItem.sexApeal;
        statistic.ergonomic -= oldItem.ergonomic;
        statistic.armor -= oldItem.armor;
        statistic.magic -= oldItem.magic;
        statistic.spikes -= oldItem.spiked;
        statistic.danger -= oldItem.danger;

        AddItem(oldItem);

        equipment.currentEquipment[slotIndex] = null;

        if (onItemChangeCallback != null)
            onItemChangeCallback.Invoke();

        Defocus(false);
    }

}
