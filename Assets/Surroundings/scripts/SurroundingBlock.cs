using System;
using Ink.Parsed;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundingBlock : MonoBehaviour
{
    //При захождении на тайл с предметом в окружении - показать клавишу "Взять ...(предмет)" 
    //Если там хранилища - то там появляется обыск и "Вражеский инвентарь"
    //Тут просто лист с предметами, по сути, если есть хранилища - то ещё и с 
    [SerializeField] private List<item> itemsOnTile;
    [SerializeField] private List<item> storagesOnTile;
    [SerializeField] private TextAsset spawnJson;
    DialogManager instanceOfTheManager;
    private bool playerInLocation = false;

    private void Start()
    {
        instanceOfTheManager = DialogManager.GetInstance();
    }

    private void Awake()
    {
        
        Debug.Log("Stuff");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //DialogManager.GetInstance().GutSurroundingNode();
            playerInLocation = false;
        }
    }

}
