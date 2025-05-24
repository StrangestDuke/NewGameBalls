using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject EquipmentPanel;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private Image Icon;
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;

    public static Inventory instance;

    public int space = 88;

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
        items.Add(item);
        if (onItemChangeCallback != null)
            onItemChangeCallback.Invoke();
    }
    public void RemoveItem(item item) 
    { 
        items.Remove(item);
        if (onItemChangeCallback != null)
            onItemChangeCallback.Invoke();
    }

    public void showItem(int index)
    {
        
        Name.text = items[index].name;
        Description.text = items[index].description;
        Icon.sprite = items[index].icon;
        
    }
    
}
