using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Metadata;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject EquipmentPanel;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private Image Icon;
    //[SerializeField] private GameObject[] Buttons Examine;
    [SerializeField] private Button Examine;
    [SerializeField] private Button Use;
    [SerializeField] private Button Equip;
    [SerializeField] private Button Enchant;
    [SerializeField] private Button Drop;
    [SerializeField] private Button DropAll;
    [SerializeField] private Button Give;
    [SerializeField] private Button Brew;
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;

    [SerializeField] private GameObject InventoryLayout;

    //Предмет, что на данный момент "Выделен"
    item takenItem;

    public static Inventory instance;

    public int space = 88;


    InventorySlot[] childrenOfLayout;

    private void Start()
    {
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


    public List<item> items = new List<item>();

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

}
