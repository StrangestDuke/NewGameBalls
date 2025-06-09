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
    [SerializeField] private GameObject StatsPanel;
    [SerializeField] private CharAtrFiiling StatsLogic;
    [SerializeField] private GameObject CharacteristicsPanel;
    [SerializeField] private GameObject TreePanel; 

    public void logic()
    {
        switch (index)
        {
            case 0:
                OpenInventory();
                break;
            case 1:
                CloseInventory();
                break;
            case 2:
                CloseStats();
                break;
            case 3:
                OpenStats();
                break;
            case 4:
                OpenTree();
                break;
            case 5:
                CloseTree();
                break;
            default:
                Debug.Log("Wtf is that shit with menu");
        break;
        }

    }
    public void OpenInventory()
    {
        index = 1;
        SurroundingPanel.SetActive(false);
        DialoguePanel.SetActive(false);
        EquipmentPanel.SetActive(true);
        InventaryPanel.SetActive(true);
        CharacteristicsPanel.SetActive(false);
        StatsPanel.SetActive(false);
        TreePanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void CloseInventory()
    {
        index = 0;
        SurroundingPanel.SetActive(true);
        DialoguePanel.SetActive(true);
        EquipmentPanel.SetActive(false);
        InventaryPanel.SetActive(false);
        CharacteristicsPanel.SetActive(false);
        StatsPanel.SetActive(false);
        TreePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenStats()
    {
        StatsLogic.FillingEverything();
        index = 2;
        SurroundingPanel.SetActive(false);
        DialoguePanel.SetActive(false);
        EquipmentPanel.SetActive(false);
        InventaryPanel.SetActive(false);
        CharacteristicsPanel.SetActive(true);
        StatsPanel.SetActive(true);
        TreePanel.SetActive(false);

        Time.timeScale = 0f;
    }

    public void CloseStats()
    {
        index = 3;
        SurroundingPanel.SetActive(true);
        DialoguePanel.SetActive(true);
        EquipmentPanel.SetActive(false);
        InventaryPanel.SetActive(false);
        CharacteristicsPanel.SetActive(false);
        StatsPanel.SetActive(false);
        TreePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenTree()
    {
        index = 5;
        SurroundingPanel.SetActive(false);
        DialoguePanel.SetActive(false);
        EquipmentPanel.SetActive(false);
        InventaryPanel.SetActive(false);
        CharacteristicsPanel.SetActive(false);
        StatsPanel.SetActive(false);
        TreePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseTree()
    {
        OpenStats();
    }

    public void OnClickTree()
    {
        //if inventory is open - it would just close it
        if (index != 5)
        {

            index = 4;
        }
        logic();
    }
    public void OnClickStats()
    {
        //if inventory is open - it would just close it
        if (index != 2)
        {
            
            index = 3;
        }
        logic();
    }
    public void OnClickInventory()
    {
        //if inventory is open - it would just close it
        if (index != 1)
        {
            index = 0;
        }
        logic();
    }



}
