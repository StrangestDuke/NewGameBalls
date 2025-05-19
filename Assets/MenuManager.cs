using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using System;
public class MenuManager : MonoBehaviour
{
    private int index = 0;
    [SerializeField] public GameObject Button;
    [SerializeField] private GameObject SurroundingPanel;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private GameObject EquipmentPanel;
    [SerializeField] private GameObject InventaryPanel;
    

    public void onClick()
    {

        if (index == 0)
        {
            OpenInventory();
        }
        else
        {
            CloseInventory();
        }
    }
    public void OpenInventory()
    {
        index = 1;
        SurroundingPanel.SetActive(false);
        DialoguePanel.SetActive(false);
        EquipmentPanel.SetActive(true);
        InventaryPanel.SetActive(true);
        Time.timeScale = 0f;
        Button.gameObject.GetComponentInChildren<TMP_Text>().text = "World";
    }

    public void CloseInventory()
    {
        index = 0;
        SurroundingPanel.SetActive(true);
        DialoguePanel.SetActive(true);
        EquipmentPanel.SetActive(false);
        InventaryPanel.SetActive(false);
        Time.timeScale = 1f;
        Button.gameObject.GetComponentInChildren<TMP_Text>().text = "inventory";
    }
}
