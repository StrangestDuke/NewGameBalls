using System;
using Ink.Parsed;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SurroundingDesc : MonoBehaviour
{
    //При захождении на тайл с предметом в окружении - показать клавишу "Взять ...(предмет)" 
    //Если там хранилища - то там появляется обыск и "Вражеский инвентарь"
    //Тут просто лист с предметами, по сути, если есть хранилища - то ещё и с 
    [SerializeField] public List<item> itemsOnTile;

    public int ammountOfItemOnTile = 1;
    [SerializeField] private List<item> storagesOnTile;
    [SerializeField] public Dictionary<item, int> itemsInTile;
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private TextAsset spawnJson;
    DialogManager instanceOfTheManager;
    private bool playerInLocation = false;

    private void Start()
    {
        instanceOfTheManager = DialogManager.GetInstance();
    }

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            instanceOfTheManager.EnterSurroundingNode(inkJson);
            instanceOfTheManager.WriteCurrentObject(gameObject);

            if(itemsOnTile.Count != 0)
            {
                instanceOfTheManager.DisplayItemsPickups(itemsOnTile);
            }
            playerInLocation = true;
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
    public void DropItemInTile(item item)
    {
        //itemsInTile.Add(item);
    }
}
